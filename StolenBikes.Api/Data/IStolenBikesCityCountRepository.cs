using System.Collections.Generic;
using StolenBikes.Api.Models.Dtos;

namespace StolenBikes.Api.Data
{
    public interface IStolenBikesCityCountRepository
    {
        void SaveStolenBikesCityCount(StolenBikesCityCount stolenBikesCityCount);
        
        IEnumerable<StolenBikesCityCount> GetStolenBikesCityCountList();
        
        StolenBikesCityCount GetStolenBikesCityCount(string cityName);
    }
}