using Microsoft.EntityFrameworkCore;
using perla_metro_users_service.Authentication;
using perla_metro_users_service.Authentication.Token;
using perla_metro_users_service.Data;
using perla_metro_users_service.Mapper;
using perla_metro_users_service.Model;
using perla_metro_users_service.Repository;
using perla_metro_users_service.service;
using perla_metro_users_service.Util;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration["ConnectionStrings"];
var secret = builder.Configuration["Secret"];
var audience = builder.Configuration["Audience"];
var issuer = builder.Configuration["Issuer"];

Console.WriteLine(connectionString);
Console.WriteLine(secret);
Console.WriteLine(audience);
Console.WriteLine(issuer);

builder
    .Services
    .AddDbContext<ApplicationDbContext>(
        op => op.UseNpgsql(connectionString));

builder.Services.AddScoped<IEncryptStrategy, BcryptEncryptStrategy>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserTokenProvider, JwtUserTokenProvider>();
builder.Services.AddScoped<IAuthenticatorHandler, AuthenticationHandler>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>(); 
        await dbContext.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al aplicar las migraciones de la base de datos.");
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
  
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

