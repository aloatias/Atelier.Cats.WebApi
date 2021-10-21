using Atelier.Cats.DataAccess.Extensions;
using Atelier.Cats.WebApi.Extensions;
using Atelier.Gateway.Configuration;
using Atelier.Gateway.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Atelier.Cats.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Atelier.Cats.WebApi", Version = "v1" });
            });

            services.AddLogging();

            InjectCustomServices(services);

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Atelier.Cats.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InjectCustomServices(IServiceCollection services)
        {
            // Data Access
            DataAccessConfiguration.InjectServices(services);

            // Core Services
            CoreServicesConfiguration.ConfigureServices(services);

            // Atelier Gateway
            CatsGatewayConfiguration.InjectServices(services, Configuration);

            // Configuration
            services.Configure<AtelierCatsUrlOptions>(Configuration.GetSection("Urls"));
        }
    }
}
