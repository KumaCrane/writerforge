using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WriterForge.Services;

namespace WriterForge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Регистрация сервисов
            services.AddScoped<IWordCounterService, Services.WordCounterService>();
            services.AddScoped<ITimerService, Services.TimerService>();
            services.AddScoped<IMusicIntegrationService, Services.MusicIntegrationService>();
            services.AddScoped<ISpellCheckerService, Services.SpellCheckerService>();
            services.AddScoped<ICloudStorageService, Services.CloudStorageService>();
            services.AddControllers();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}