using System.Threading.Tasks;
using StolenBikes.Api.Models.Dtos;

namespace StolenBikes.Api.Services.Interfaces
{
    public interface IBikeIndexService
    {
        Task<int> GetStolenBikesCount(City city);
    }
}