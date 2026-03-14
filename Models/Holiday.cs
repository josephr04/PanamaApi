namespace PanamaApi.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameEs { get; set; }
        public DateOnly Date { get; set; }
        public string? Type { get; set; }
    }
}
