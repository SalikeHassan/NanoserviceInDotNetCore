using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pattern.Nanoservice.API.Client;
using Pattern.Nanoservice.Infrastructure.Context;
using System;
using System.Net.Http.Headers;

namespace Pattern.Nanoservice.API
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
            services.AddHttpClient<CandidateHttpClient>(c =>
            {
                c.BaseAddress = new Uri(this.Configuration["FunctionUrl"]);
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.ConnectionClose = false;
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
                c.DefaultRequestHeaders.Add("aeg-sas-key", this.Configuration["FunctionAppSubsKey"]);
            });

            services.AddCors(options =>
                 {
                     options.AddPolicy(
                         "DemoAPICORSPolicy",
                         builder =>
                         {
                             builder
                                 .WithOrigins(this.Configuration.GetSection($"DemoAPICORSPolicy:Origins").Get<string[]>())
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();
                         });
                 });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pattern.Nanoservice.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pattern.Nanoservice.API v1"));
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
