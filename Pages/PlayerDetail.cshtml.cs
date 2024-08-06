using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace League.Pages
{
    public class PlayerModel : PageModel
    {
        private readonly LeagueContext _context;

        public PlayerModel(LeagueContext context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task OnGetAsync(string Id)
        {
            Player = await _context.Players.FindAsync(Id); //use Player
        }
    }
}
