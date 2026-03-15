namespace PanamaApi.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Ced { get; set; }
        public string? IsoCode { get; set; }
        public string? Capital { get; set; }
        public int? Population { get; set; }
        public decimal? AreaKm2 { get; set; }
    }
}
