using Core.Model.Identity;
using Infrastructure.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace syv_api.Extension
{
    public static class DBServiceExtensions
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySql(
                    config.GetConnectionString("ConnectionString"),
                    new MySqlServerVersion(new Version(8, 0, 31)),
                    b => b.MigrationsAssembly("Infrastructure")
                    );
            });

            services.AddIdentityCore<AppUser>(o =>
            {

            }).AddEntityFrameworkStores<AppDbContext>().AddSignInManager<SignInManager<AppUser>>();

            return services;
        }
    }
}
