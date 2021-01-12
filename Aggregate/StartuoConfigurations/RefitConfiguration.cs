using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Refit;
using Aggregate.Services;

namespace Producer.StartupConfiguration
{

    public static class RefitConfiguration
    {
        public static IServiceCollection Refit(this IServiceCollection services, IConfiguration section)
        {
            var carfoureApi = section.GetSection("Urls:CarfoureApi").Value;
            var a101Api = section.GetSection("Urls:A101Api").Value;
            services.AddRefitClient<IA101Service>()
                .ConfigureHttpClient(config =>
                {
                    config.BaseAddress = new Uri(a101Api);
                    config.Timeout = TimeSpan.FromMinutes(2);
                });
            services.AddRefitClient<ICarfoureService>()
              .ConfigureHttpClient(config =>
              {
                  config.BaseAddress = new Uri(carfoureApi);
                  config.Timeout = TimeSpan.FromMinutes(2);
              });

            return services;
        }
    }

}
