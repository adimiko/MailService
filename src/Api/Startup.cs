using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Core.Domain.Entities;
using Core.Repositories;
using Infrastructure.Mapper;
using Infrastructure.MimeKit;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
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
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IEmailSettingsService, EmailSettingsService>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IEmailSettingsRepository,EmailSettingsRepository>();
            services.AddSingleton<IMailKitProvider, MailKitProvider>();
            services.AddSingleton<IMailKitConfig, MailKitConfig>();
            services.AddSingleton(AutoMapperConfig.Initialize());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
