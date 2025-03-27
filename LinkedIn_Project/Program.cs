using Application.Security;
using Application.Services;
using DAL.SqlServer;
using DAL.SqlServer.Infrastructure;
using Domain.Entities;
using LinkedIn_Project.Infrastructure;
using LinkedIn_Project.Security;
using Microsoft.AspNetCore.Identity;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, SqlUserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserContext, HttpUserContext>();


var conn = builder.Configuration.GetConnectionString("MyConn");
builder.Services.AddSqlServerServices(conn!);
builder.Services.AddApplicationServices();
builder.Services.AddAuthenticationService(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//HELE KI MIDDLEWARE YAZMAMISHAM, YAZIM ONLARI DA QEYD EDECEM

//app.UseMiddleware<RateLimitMiddleware>(2, TimeSpan.FromMinutes(1));
//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();
