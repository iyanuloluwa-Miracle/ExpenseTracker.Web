namespace Client.DTOs.Dashboard
{
    public class CategorySummaryResponse
    {
        public string CategoryId { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public decimal Percentage { get; set; }
    }
} 