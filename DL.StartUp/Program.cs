using System.Reflection;
using DinkToPdf;
using DinkToPdf.Contracts;
using DL.Audit.Services;
using DL.Auth.Services;
using DL.Directories.Services;
using DL.Migrator.Services;
using DL.StartUp.Middleware;
using Gelf.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

var grayLogEnabled = builder.Configuration.GetValue("Graylog:Enabled", false);
if (grayLogEnabled)
{
    var grayLogHost = builder.Configuration["Graylog:Host"];
    var grayLogPort = builder.Configuration.GetValue<int>("Graylog:Port");
    
    if (!string.IsNullOrEmpty(grayLogHost))
    {
        builder.Logging.AddGelf(options =>
        {
            options.Protocol = GelfProtocol.Udp;
            options.LogSource = builder.Environment.ApplicationName;
            options.AdditionalFields["machine_name"] = Environment.MachineName;
            options.AdditionalFields["app_version"] = Assembly.GetEntryAssembly()
                ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        });
    }
    else
    {
        Console.WriteLine("Graylog host not configured, using console logging");
        builder.Logging.AddConsole();
    }
}
else
{
    builder.Logging.AddConsole();
}

builder.Services.AddMigrator();
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddDirectoriesRepository(builder.Configuration);
builder.Services.AddProduct();
builder.Services.AddProductName();
builder.Services.AddProductType();
builder.Services.AddStorageLocation();
builder.Services.AddAudit(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IConverter>(new SynchronizedConverter(new PdfTools()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var migrationService = scope.ServiceProvider.GetRequiredService<Migrator>();
    migrationService.UpdateDatabase();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();