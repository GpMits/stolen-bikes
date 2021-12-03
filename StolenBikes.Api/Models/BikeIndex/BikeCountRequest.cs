using System.Reflection.Emit;

namespace StolenBikes.Api.Models.Dtos.BikeIndex
{
    public class BikeCountRequest
    {
        public string Location { get; set; }
        
        public int? Distance { get; set; }

        public string BuildSearchQuery()
        {
            var searchQuery = string.Empty;

            if (!string.IsNullOrEmpty(Location))
            {
                searchQuery += $"?location={Location}";
            }

            if (Distance.HasValue)
            {
                searchQuery += $"&distance={Distance}";
            }

            return searchQuery;
        }

        public override string ToString()
        {
            return $"{Location}_{Distance}";
        }
    }
}