using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace League.Pages.Team
{
    public class TeamDetailModel : PageModel
    {
        private readonly LeagueContext _context;

        public TeamDetailModel(LeagueContext context)
        {
            _context = context;
        }
        public Models.Team Team { get; set; }
        public Models.TeamStats TeamStat { get; set; }

        public LeagueContext Get_context()
        {
            return _context;
        }

        public async Task<IActionResult> OnGetAsync(string Id)
        {
            Team = await _context.Teams
                .Include(c => c.Players)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeamId == Id);


            var teamstat = from b in _context.Teams
                           where b.TeamId == Id
                           select new TeamStats
                           {
                               WinLossRatio = b.Win / b.Loss
                           };
            TeamStat = await teamstat.SingleOrDefaultAsync();
            return Page();
        }
    }
}
