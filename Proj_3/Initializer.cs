using Domain.Entity;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Proj_3.DAL.Interfaces;
using Proj_3.DAL.Repositories;
using Team.Service.Implementations;
using Team.Service.Interfaces;

namespace Proj_3
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
            services.AddScoped<IBaseRepository<Domain.Entity.Team>,TeamRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamService,TeamService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();

        }
    }
}
