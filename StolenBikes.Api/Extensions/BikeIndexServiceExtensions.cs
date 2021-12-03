using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StolenBikes.Api.Services;
using StolenBikes.Api.Services.Interfaces;

namespace StolenBikes.Api.Extensions
{
    public static class BikeIndexServiceExtensions
    {
        public static void RegisterBikeIndexService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IBikeIndexService, BikeIndexService>(
                client => client.BaseAddress = GetBikeIndexApiUri(configuration));
        }
        
        private static Uri GetBikeIndexApiUri(IConfiguration configuration)
        {
            return new Uri($"{configuration["BikeIndexApi:BaseAddress"]}");
        }
    }
}