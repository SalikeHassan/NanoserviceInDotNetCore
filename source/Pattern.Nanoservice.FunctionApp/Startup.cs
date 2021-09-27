using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pattern.Nanoservice.Infrastructure.Context;
using System;
using System.IO;

[assembly: FunctionsStartup
    (typeof(Pattern.Nanoservice.FunctionApp.Startup))]
namespace Pattern.Nanoservice.FunctionApp
{
    public class Startup : FunctionsStartup
    {
        private IConfiguration Configuration;

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {

            FunctionsHostBuilderContext context = builder.GetContext();

            builder.ConfigurationBuilder
                .AddJsonFile(Path.Combine(context.ApplicationRootPath, "local.settings.json"), optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            this.Configuration = builder.ConfigurationBuilder.Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContextPool<CandidateContext>(options => options.UseSqlServer(
              this.Configuration.GetConnectionString("CandidateConnection"), x =>
              {
                  x.MigrationsHistoryTable("__MigrationsHistoryForCandidate", "candidate");
              }));

            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            var serviceAssemble = AppDomain.CurrentDomain.Load("Pattern.Nanoservice.Service");
            builder.Services.AddMediatR(serviceAssemble);
        }
    }
}
