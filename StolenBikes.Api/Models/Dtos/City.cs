using StolenBikes.Api.Models.Dtos.BikeIndex;

namespace StolenBikes.Api.Models.Dtos
{
    public class City
    {
        public string Name { get; set; }
        
        public string Latitude { get; set; }
        
        public string Longitude { get; set; }
        
        public int? Radius { get; set; }

        public BikeCountRequest ToBikeCountRequest()
        {
            return new BikeCountRequest
            {
                Distance = Radius,
                Location = !string.IsNullOrEmpty(Latitude) && !string.IsNullOrEmpty(Longitude) 
                    ? $"{Latitude},{Longitude}" 
                    : Name
            };
        }
    }
}