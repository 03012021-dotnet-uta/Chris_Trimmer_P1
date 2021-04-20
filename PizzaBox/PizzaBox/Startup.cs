using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Models;


namespace PizzaBox
{

    /// <summary>
    /// This is the startup class for the project
    /// It sets the DbContext and controllers
    /// to the services used by the app.
    /// The connection string is protected by User Secret
    /// Dependency Injection: DbContext is registered as a service,
    /// so that it can be injected in each controller.
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to add services to the container.
        /// Registers PizzaBox DbContext to the service collection.
        /// This is what enables Dependency Injection.
        /// Now the controllers can use the DbContext
        /// without creating a dependency.
        /// </summary>
        /// <param name="services"></param>
        // 
        public void ConfigureServices(IServiceCollection services)
        {

            string connectionString = Configuration.GetConnectionString("PizzaBox");

            services.AddDbContext<PizzaBoxContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
