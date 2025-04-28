namespace Client.DTOs.Dashboard
{
    public class DashboardSummaryResponse
    {
        public decimal TotalExpenses { get; set; }
        public decimal AverageSpending { get; set; }
        public decimal HighestExpense { get; set; }
        public decimal LowestExpense { get; set; }
        public int TotalTransactions { get; set; }
    }
} 