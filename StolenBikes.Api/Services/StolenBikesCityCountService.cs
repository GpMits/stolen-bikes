using System.Collections.Generic;
using System.Threading.Tasks;
using StolenBikes.Api.Data;
using StolenBikes.Api.Exceptions;
using StolenBikes.Api.Models.Dtos;
using StolenBikes.Api.Services.Interfaces;

namespace StolenBikes.Api.Services
{
    public class StolenBikesCityCountService : IStolenBikesCityCountService
    {

        private readonly IStolenBikesCityCountRepository _stolenBikesCityCountRepository;
        
        private readonly IBikeIndexService _bikeIndexService;
        
        public StolenBikesCityCountService(
            IStolenBikesCityCountRepository stolenBikesCityCountRepository,
            IBikeIndexService bikeIndexService)
        {
            _stolenBikesCityCountRepository = stolenBikesCityCountRepository;
            _bikeIndexService = bikeIndexService;
        }
        
        public StolenBikesCityCount GetStolenBikesCityCount(string cityName)
        {
            return _stolenBikesCityCountRepository.GetStolenBikesCityCount(cityName.ToLower());
        }

        public async Task<StolenBikesCityCount> SaveStolenBikesCityCount(City city)
        {
            var stolenBikesCityCount = GetStolenBikesCityCount(city.Name);

            if (stolenBikesCityCount is not null)
            {
                throw new EntityAlreadyExistsException();
            }
            
            var stolenBikesAmount = await _bikeIndexService.GetStolenBikesCount(city);
            stolenBikesCityCount = new StolenBikesCityCount
            {
                City = city,
                StolenBikesAmount = stolenBikesAmount
            };
            
            _stolenBikesCityCountRepository.SaveStolenBikesCityCount(stolenBikesCityCount);

            return stolenBikesCityCount;
        }

        public IEnumerable<StolenBikesCityCount> GetStolenBikesCityCountList()
        {
            return _stolenBikesCityCountRepository.GetStolenBikesCityCountList();
        }
    }
}