using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using open_api.Configurations;
using open_api.Infrastructure;
using open_api.Services;
using open_api.Services.Interface;

namespace open_api
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
            InitialiseMvc(services);
            InitialiseConfiguration(services);
            InitialiseServices(services);
            InitialseSWagger(services);
        }

        private void InitialiseServices(IServiceCollection services)
        {
            services.AddTransient<IService, Service>();
        }

        private void InitialiseConfiguration(IServiceCollection services)
        {
            services.Configure<BaseUrl>(Configuration.GetSection("BaseUrl"));
        }

        private void InitialiseMvc(IServiceCollection services)
        {
            services
                .AddControllers(o => o.Conventions.Add(new ApiExplorerIgnores()));
        }

        private void InitialseSWagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                "v1",
                new OpenApiInfo { Title = "API", Version = "1" });
            });
        }
 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
