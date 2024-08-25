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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SortField { get; set; }

        public TeamModel(ILogger<TeamModel> logger, LeagueContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            var teams = from c in _context.Teams
                        select c;
            if(!string.IsNullOrEmpty(SearchString))
            {
                teams = teams.Where(c => c.Name.Contains(SearchString));
            }
            switch (SortField)
            {
                case "TeamId":
                    teams = teams.OrderBy(c => c.TeamId);
                    break;
                case "Name":
                    teams = teams.OrderBy(c => c.Name);
                    break;
            }

            Teams = await teams.ToListAsync();
        }

    }
}
