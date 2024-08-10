using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace League.Pages
{
    public class TeamDetailModel : PageModel
    {
        private readonly LeagueContext _context;

        public TeamDetailModel(LeagueContext context)
        {
            _context = context;
        }
        public Team Team { get; set;}
        public async Task OnGetAsync(string Id)
        {
            Team = await _context.Teams.FindAsync(Id); //use Team
        }
    }
}
