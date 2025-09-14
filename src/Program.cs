using Microsoft.EntityFrameworkCore;
using perla_metro_users_service.Data;
using perla_metro_users_service.Mapper;
using perla_metro_users_service.Model;
using perla_metro_users_service.Repository;
using perla_metro_users_service.service;
using perla_metro_users_service.Util;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var connectionString = builder.Configuration["ConnectionStrings:default"];
Console.WriteLine(connectionString);

builder
    .Services
    .AddDbContext<ApplicationDbContext>(
        op => op.UseNpgsql(connectionString));

builder.Services.AddScoped<IEncryptStrategy, BcryptEncryptStrategy>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
  
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

