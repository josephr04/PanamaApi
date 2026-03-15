namespace PanamaApi.Models
{
    public class President
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Party { get; set; }
    }
}