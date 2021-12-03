using System.Collections.Generic;
using System.Threading.Tasks;
using StolenBikes.Api.Models.Dtos;

namespace StolenBikes.Api.Services.Interfaces
{
    public interface IStolenBikesCityCountService
    {
        StolenBikesCityCount GetStolenBikesCityCount(string cityName);
        
        Task<StolenBikesCityCount> SaveStolenBikesCityCount(City city);
        
        IEnumerable<StolenBikesCityCount> GetStolenBikesCityCountList();
    }
}