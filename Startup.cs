using functions;
using functions.Services;
using functions.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(AllService.Functions.Startup))]

namespace AllService.Functions
{
    class Startup : FunctionsStartup
    {
        private IConfiguration _configuration;
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureSettings(builder);
            builder.Services.AddSingleton<IMailService, MailService>();
        }

        private void ConfigureSettings(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            _configuration = config;

            var mailServiceSettings = new MailServiceSettings()
            {
                SMTPFromAddress = _configuration["MailService:SMTPFromAddress"]
            };

            builder.Services.AddSingleton(mailServiceSettings);
        }
    }
}