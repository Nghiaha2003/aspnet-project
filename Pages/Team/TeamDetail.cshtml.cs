using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace League.Pages.Team
{
    public class TeamDetailModel : PageModel
    {
        private readonly LeagueContext _context;

        [BindProperty]
        public string Id { get; set; }
        public TeamDetailModel(LeagueContext context)
        {
            _context = context;
        }
        public Models.Team Team { get; set; }
        public async Task OnGetAsync(string Id)
        {
            Team = await _context.Teams.FindAsync(Id); //use Team
        }
    }
}
