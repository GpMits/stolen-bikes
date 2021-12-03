namespace StolenBikes.Api.Models.Dtos.BikeIndex
{
    public class BikeCountResponse
    {
        public int Proximity { get; set; }
        public int Stolen { get; set; }
        public int Non { get; set; }
    }
}