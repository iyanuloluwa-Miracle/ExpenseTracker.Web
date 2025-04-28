using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client.Services;
using Client.DTOs.Dashboard;

namespace Client.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly DashboardService _dashboardService;

        public IndexModel(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public DashboardSummaryResponse Summary { get; set; } = new();
        public IEnumerable<CategorySummaryResponse> CategorySummary { get; set; } = Enumerable.Empty<CategorySummaryResponse>();
        public IEnumerable<MonthlySummaryResponse> MonthlySummary { get; set; } = Enumerable.Empty<MonthlySummaryResponse>();

        public async Task OnGetAsync()
        {
            Summary = await _dashboardService.GetSummaryAsync();
            CategorySummary = await _dashboardService.GetCategorySummaryAsync();
            MonthlySummary = await _dashboardService.GetMonthlySummaryAsync();
        }
    }
} 