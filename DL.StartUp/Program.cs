using DinkToPdf;
using DinkToPdf.Contracts;
using DL.Audit.Services;
using DL.Auth.Services;
using DL.Directories.Services;
using DL.Graylog;
using DL.Migrator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraylog();
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
        policy.WithOrigins("http://localhost:3000", "http://193.124.118.54:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

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