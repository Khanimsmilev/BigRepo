using Application.Security;
using Common.Security;
using DAL.SqlServer;
using LinkedIn_Project.Infrastructure;
using LinkedIn_Project.Security;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSwaggerService();
builder.Services.AddScoped<IUserContext, HttpUserContext>();
builder.Services.AddScoped<ICustomPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();

builder.Services.AddCors(opt=>
{
    opt.AddPolicy("AllowFrontEnd", policy =>
    {
        policy.WithOrigins("http://localhost:5178")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
       
});



builder.Services.AddSwaggerGen();


var conn = builder.Configuration.GetConnectionString("MyConn");
builder.Services.AddSqlServerServices(conn!);
builder.Services.AddApplicationServices();
builder.Services.AddAuthenticationService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontEnd");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


//HELE KI MIDDLEWARE YAZMAMISHAM, YAZIM ONLARI DA QEYD EDECEM

//app.UseMiddleware<RateLimitMiddleware>(2, TimeSpan.FromMinutes(1));
//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();
