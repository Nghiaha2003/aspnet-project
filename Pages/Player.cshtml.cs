using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace League.Pages
{
    public class AllPlayersModel : PageModel
    {
        private readonly LeagueContext _context;

        public AllPlayersModel(LeagueContext context)
        {
            _context = context;
        }

        public List<Player> AllPlayers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedTeam { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedPosition { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortField { get; set; } = "Name";

        [BindProperty(SupportsGet = true)]
        public string SortDirection { get; set; } = "asc";
        public SelectList Teams { get; set; }
        public SelectList Positions { get; set; }
        public string FavouriteTeam { get; set; } //still in implement

        public async Task OnGetAsync()
        {
            //select all players in dbset
            var players = from p in _context.Players
                          select p;
            //wwhen search player
            if (!string.IsNullOrEmpty(SearchString))
            {
                players = players.Where(p => p.Name.Contains(SearchString));
            }

            //wwhen filter team
            if (!string.IsNullOrEmpty(SelectedTeam))
            {
                players = players.Where(p => p.TeamId == SelectedTeam);
            }
            //wwhen filter possition
            if (!string.IsNullOrEmpty(SelectedPosition))
            {
                players = players.Where(p => p.Position == SelectedPosition);
            }

            switch (SortField)
            {
                /*
                case "Number":
                    players = SortDirection == "asc" ? players.OrderBy(p => p.Number).ThenBy(p => p.TeamId) : players.OrderByDescending(p => p.Number).ThenBy(p => p.TeamId);
                    break;
                case "Name":
                    players = SortDirection == "asc" ? players.OrderBy(p => p.Name).ThenBy(p => p.TeamId) : players.OrderByDescending(p => p.Name).ThenBy(p => p.TeamId);
                    break;
                case "Position":
                    players = SortDirection == "asc" ? players.OrderBy(p => p.Position).ThenBy(p => p.TeamId) : players.OrderByDescending(p => p.Position).ThenBy(p => p.TeamId);
                    break;
                    */
                case "Number":
                    players = players.OrderBy(p => p.Number).ThenBy(p => p.TeamId);
                    break;
                case "Name":
                    players = players.OrderBy(p => p.Name).ThenBy(p => p.TeamId);
                    break;
                case "Position":
                    players = players.OrderBy(p => p.Position).ThenBy(p => p.TeamId);
                    break;
                case "NumberDesc":
                    players = players.OrderByDescending(p => p.Number).ThenBy(p => p.TeamId);
                    break;
                case "NameDesc":
                    players = players.OrderByDescending(p => p.Name).ThenBy(p => p.TeamId);
                    break;
                case "PositionDesc":
                    players = players.OrderByDescending(p => p.Position).ThenBy(p => p.TeamId);
                    break;
            }

            IQueryable<string> teamQuery = from t in _context.Teams
                                           orderby t.TeamId
                                           select t.TeamId;

            IQueryable<string> positionQuery = from p in _context.Players
                                               orderby p.Position
                                               select p.Position;

            //make new data for dropdown
            Teams = new SelectList(await teamQuery.ToListAsync()); //use Model.Teams to retrieve data following by asp-item= in html

            //distinctPositions = await positionQuery.Distinct().OrderBy(p => p).ToListAsync();

            //use Distinct() to remove duplicate + OrderBy(p => p) one more time to re-order in alphabetically way.
            Positions = new SelectList(await positionQuery.Distinct().OrderBy(p => p).ToListAsync()); //use Model.Positions to retrieve data following by asp-item= in html

            AllPlayers = await players.ToListAsync(); ; //use AllPlayers for data you need to retrieve
        }
        public string PlayerCSSClass(Player Player)
        {
            string css = "";
            if (Player.Depth == 1)
                css += "starter";
            if (Player.TeamId == FavouriteTeam)// still in implement
                css += "favourite";
            return css;
        }
    }
}
