namespace Mausam
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Mausam.DataAccess;
    using Mausam.Services.UserService.Interfaces;
    using Mausam.Services.UserService;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using AspNetCore.Identity.Mongo;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add configuration
            services.Configure<MongoDbConfiguration>(Configuration.GetSection("MongoDB"));

            // Add MongoDB DbContext
            services.AddSingleton<MongoDbContext>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                return new MongoDbContext(configuration);
            });

            // Add MVC with views support
            services.AddControllersWithViews();

            // Add user service
            services.AddScoped<IUserCheckin, UserCheckin>();

            // Add logging (optional)
            services.AddLogging();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable HTTPS redirection (optional, for production)
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Include the following line to enable views
            app.UseAuthorization();
            app.UseStaticFiles(); // Enable serving static files like images, CSS, etc.
        }
    }
}
