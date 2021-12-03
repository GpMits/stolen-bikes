using System.Collections.Generic;
using System.Linq;
using StolenBikes.Api.Models.Dtos;

namespace StolenBikes.Api.Data
{
    public class StolenBikesCityCountRepository : IStolenBikesCityCountRepository
    {
        private readonly IList<StolenBikesCityCount> _stolenBikesCityCountList;

        public StolenBikesCityCountRepository()
        {
            _stolenBikesCityCountList = new List<StolenBikesCityCount>();
        }


        public void SaveStolenBikesCityCount(StolenBikesCityCount stolenBikesCityCount)
        {
            if (GetStolenBikesCityCount(stolenBikesCityCount.City.Name) is null)
            {
                _stolenBikesCityCountList.Add(stolenBikesCityCount);
            }
        }

        public IEnumerable<StolenBikesCityCount> GetStolenBikesCityCountList()
        {
            return _stolenBikesCityCountList;
        }

        public StolenBikesCityCount GetStolenBikesCityCount(string cityName)
        {
            return _stolenBikesCityCountList.FirstOrDefault(
                stolenBikesCityCount =>
                    stolenBikesCityCount.City.Name.ToLower().Equals(cityName.ToLower()));
        }
    }
}