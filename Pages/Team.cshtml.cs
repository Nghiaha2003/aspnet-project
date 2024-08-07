using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace League.Pages
{
    public class TeamModel : PageModel
    {
        public readonly LeagueContext _context;

        public TeamModel(LeagueContext context)
        {
            _context = context;
        }

        public List<Team> Teams { get; set; }


        public async Task OnGetAsync()
        {
            var teams = from c in _context.Teams
                            select c;



            IQueryable<string> teamQuery = from c in _context.Teams
                                                orderby c.DivisionId
                                                select c.DivisionId;

            Teams = await teams.ToListAsync();
        }
    }
}
