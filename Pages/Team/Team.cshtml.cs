using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using League.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace League.Pages.Team
{
    public class TeamModel : PageModel
    {
        private readonly ILogger<TeamModel> _logger;
        private readonly LeagueContext _context;
        public List<Models.Team> Teams { get; set; }
        public TeamModel(ILogger<TeamModel> logger, LeagueContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            var teams = from c in _context.Teams
                        select c;

            Teams = await teams.ToListAsync();
        }

    }
}
