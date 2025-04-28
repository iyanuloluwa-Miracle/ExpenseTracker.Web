namespace Client.DTOs.Dashboard
{
    public class MonthlySummaryResponse
    {
        public string Month { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
} 