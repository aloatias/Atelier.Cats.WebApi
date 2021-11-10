using Atelier.Cats.Application;
using Atelier.Cats.Infrastructure.Persistence.Extensions;
using Atelier.Cats.Infrastructure.Presentation;
using Atelier.Cats.WebApi.Middleware;
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
        private readonly string _policyName = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(AssemblyReference).Assembly);

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Atelier.Cats.WebApi", Version = "v1" });
            });

            services.AddLogging();
            services.AddApplicationInsightsTelemetry(Configuration["APPLICATIONINSIGHTS_CONNECTIONSTRING"]);

            InjectCustomServices(services);
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
            app.UseAuthentication();
            app.UseCors(_policyName);
            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials
        }

        private void InjectCustomServices(IServiceCollection services)
        {
            // Persistence
            PersistenceServicesExtensions.InjectServices(services, Configuration);

            // Core Services
            ÂpplicationServicesExtensions.InjectServices(services);

            // Atelier Gateway
            GatewayConfigurationServicesExtensions.InjectServices(services, Configuration);

            // Configuration
            services.Configure<AtelierCatsUrlOptions>(Configuration.GetSection("Urls"));
        }
    }
}
