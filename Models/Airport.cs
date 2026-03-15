namespace PanamaApi.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IcaoCode { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Corregimiento { get; set; }
        public string? Category { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Runway { get; set; }
        public string? Surface { get; set; }
    }
}