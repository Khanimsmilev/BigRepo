using DAL.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Common;
using DAL.SqlServer.UnitOfWork;
using DAL.SqlServer.Infrastructure;
using Repository.Repositories;


namespace DAL.SqlServer;
public static class DependencyInjections
{
    public static IServiceCollection AddSqlServerServices(this IServiceCollection services, string connectionstring)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring));

        services.AddTransient<IPostRepository, SqlPostRepository>();
        services.AddTransient<IMessageRepository, SqlMessageRepository>();
        services.AddScoped<IUserRepository, SqlUserRepository>();
        services.AddScoped<IUserFollowRequestRepository, SqlUserFollowRequestRepository>();
        services.AddScoped<IUserFollowerRepository, SqlUserFollowerRepository>();
        services.AddScoped<ICommentRepository, SqlCommentRepository>();
        services.AddScoped<ILikeRepository, SqlLikeRepository>();
        //services.AddScoped<IRefreshTokenRepository, SqlRefreshTokenRepository>();

        services.AddScoped<IUnitOfWork, SqlUnitOfWork>(opt =>
        {
            var dbContext = opt.GetRequiredService<AppDbContext>();
            return new SqlUnitOfWork(connectionstring, dbContext);
        });
        return services;
    }
}