using Project.Core.Interfaces.IRepositories;
using Project.Core.Interfaces.IServices;
using Project.Core.Services;
using Project.Infrastructure.Repositories;

namespace Project.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            // services.AddSingleton<IUserContext, UserContext>();
            services.AddScoped<ICemeteryService, CemeteryService>();
            services.AddScoped<IGraveService, GraveService>();
            // services.AddScoped<IRoleService, RoleService>();
            // services.AddScoped<IUserService, UserService>();
            // services.AddScoped<IAuthService, AuthService>();

            #endregion

            #region Repositories
            services.AddTransient<ICemeteryRepository, CemeteryRepository>();
            services.AddTransient<IGraveRepository, GraveRepository>();
            // services.AddTransient<IRoleRepository, RoleRepository>();
            // services.AddTransient<IUserRepository, UserRepository>();
            // services.AddTransient<IAuthRepository, AuthRepository>();

            #endregion

            return services;
        }
    }
}