using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace League.Pages
{
    public class TeamDetailModel : PageModel
    {
        private readonly LeagueContext _context;

        public TeamDetailModel(LeagueContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}
