using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using Project.IServices;
using Project.Repositories;
using Project.Services;

namespace Project
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, MyRepository>();
            services.AddTransient<IDataBaseImagesService,DataBaseImagesService>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AnimalContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, AnimalContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller:alpha=Home}/{action:alpha=HomeScreenShow}/{id:int?}");
                
                // Same thing:

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "HomeScreenShow" },
                //    constraints: new { controller = new AlphaRouteConstraint(), action = new AlphaRouteConstraint(), id = new IntRouteConstraint() }
                //);
            });
        }
    }
}
