using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dataTransfer.Models;
using System.Linq;

namespace OlympicTeamsRoster.Controllers
{
    public class HomeController : Controller
    {
        private OlympicContext context;
        public HomeController(OlympicContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index(string activeGame = "all", string activeSport = "All")
        {
            var model = new OlympicListViewModel
            {
                ActiveGame = activeGame,
                ActiveSport = activeSport,
                Games = context.Games.ToList(),
                Sports = context.Sports.ToList()
            };
            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(t => t.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(t => t.Sport.SportID.ToLower() == activeSport.ToLower());
            model.Countries = query.ToList();
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Details(OlympicViewModel model)
        {
            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }
        [HttpGet]
        public ViewResult Details(string id)
        {
            var model = new OlympicViewModel
            {
                Country = context.Countries
                    .Include(t => t.Game)
                    .Include(t => t.Sport)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveSport = TempData?["ActiveSport"]?.ToString() ?? "all",
                ActiveGame = TempData?["ActiveGame"]?.ToString() ?? "all"
            };
            return View(model);
        }
    }
}