using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StolenBikes.Api.Data;
using StolenBikes.Api.Models.Dtos;
using StolenBikes.Api.Services;
using StolenBikes.Api.Services.Interfaces;

namespace StolenBikes.Api.Extensions
{
    public static class StolenBikesCityCountServiceExtensions
    {
        public static void RegisterStolenBikesCityCountService(this IServiceCollection services)
        {
            services.AddSingleton<IStolenBikesCityCountRepository, StolenBikesCityCountRepository>();
            services.AddSingleton<IStolenBikesCityCountService, StolenBikesCityCountService>();
        }
        
        public static void PopulateDatabaseWithDefaultCities(this IApplicationBuilder app)
        {
            var cityNames = new[] {"Amsterdam", "Berlin", "Copenhagen", "Brussels", "Milan", "London", "Paris"};
            var serviceProvider = app.ApplicationServices;
            var stolenBikesCityCountService = serviceProvider.GetService<IStolenBikesCityCountService>();
            try
            {
                Task.WaitAll(
                    cityNames
                        .Select(cityName => new City {Name = cityName})
                        .Select(city => stolenBikesCityCountService.SaveStolenBikesCityCount(city))
                        .ToArray()
                );
            }
            catch (Exception)
            {
                // Log error
                Console.Error.WriteLine("Not possible to load!");
            }
        }
    }
}