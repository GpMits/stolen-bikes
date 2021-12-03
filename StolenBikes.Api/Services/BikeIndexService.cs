using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using StolenBikes.Api.Models.Dtos;
using StolenBikes.Api.Models.Dtos.BikeIndex;
using StolenBikes.Api.Services.Interfaces;

namespace StolenBikes.Api.Services
{
    public class BikeIndexService : IBikeIndexService
    {
        private readonly HttpClient _client;

        private readonly IMemoryCache _memoryCache;

        public BikeIndexService(HttpClient client, IMemoryCache memoryCache)
        {
            _client = client;
            _memoryCache = memoryCache;
        }
        
        public async Task<int> GetStolenBikesCount(City city)
        {
            var request = city.ToBikeCountRequest();
            var response = await _memoryCache.GetOrCreateAsync(
                request.ToString(),
                entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                    return GetStolenBikesCountFromApi(request);
                }
            );

             return response.Proximity;
        }

        private async Task<BikeCountResponse> GetStolenBikesCountFromApi(BikeCountRequest request)
        {
            return await _client.GetFromJsonAsync<BikeCountResponse>
                ($"search/count/{request.BuildSearchQuery()}");
        }
    }
}