using DasherAPI.Controllers;
using DasherAPI.Data;
using DasherAPI.Endpoints;
using DasherAPI.Extensions;
using DasherAPI.Interfaces;
using DasherAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EmployeeController>();
builder.Services.AddScoped<EmployerController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<UserEndpoints>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
// Configure DB
builder.Services.AddDbContext<DasherDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddApiAuthentication(
    builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>()
);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
