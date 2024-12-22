using DL.Auth.Services;
using DL.Directories.Services;
using DL.Migrator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMigrator();
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddDirectoriesRepository(builder.Configuration);
builder.Services.AddProduct();
builder.Services.AddProductType();
builder.Services.AddStorageLocation();

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
app.UseAuthorization();
app.MapControllers();

app.Run();