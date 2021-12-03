using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StolenBikes.Api.Exceptions;
using StolenBikes.Api.Models.Dtos;
using StolenBikes.Api.Services.Interfaces;

namespace StolenBikes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StolenBikesController : ControllerBase
    {
        private readonly IStolenBikesCityCountService _stolenBikesCityCountService;
        
        public StolenBikesController(IStolenBikesCityCountService stolenBikesCityCountService)
        {
            _stolenBikesCityCountService = stolenBikesCityCountService;
        }

        [HttpGet]
        public IActionResult GetStolenBikesCityCountList()
        {
            var stolenBikesCityCountList = _stolenBikesCityCountService.GetStolenBikesCityCountList();
            return Ok(stolenBikesCityCountList);
        }
        
        [HttpPost("{cityName}")]
        public async Task<IActionResult> SaveGetStolenBikesCity(string cityName)
        {
            var city = new City {Name = cityName};
            return await SaveGetStolenBikesCity(city);
        }
        
        [HttpPost]
        public async Task<IActionResult> SaveGetStolenBikesCity([FromBody]City city)
        {
            StolenBikesCityCount stolenBikesCityCount;
            
            try
            {
                stolenBikesCityCount = await _stolenBikesCityCountService.SaveStolenBikesCityCount(city);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Problem(e.Message, statusCode: 409);
            }

            return Ok(stolenBikesCityCount);
        }
    }
}