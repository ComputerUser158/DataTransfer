using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using dataTransfer.Models;

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
            var session = new CountrySession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveSport(activeSport);

            
            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new CountryCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0)
                {
                    mycountries = context.Countries.Include(testc => testc.Game)
                        .Include(t => t.Sport)
                        .Where(t => ids.Contains(t.CountryID)).ToList();
                }
                session.SetMyCountries(mycountries);
            }

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

        
        [HttpGet]
        public ViewResult Details(string id)
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new OlympicViewModel
            {
                Country = context.Countries
                    .Include(t => t.Game)
                    .Include(t => t.Sport)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveSport = session.GetActiveGame(),
                ActiveGame = session.GetActiveSport()
            };
            return View(model);
        }

        
        [HttpPost]
        public RedirectToActionResult Add(OlympicViewModel model)
        {
            model.Country = context.Countries  
                .Include(t => t.Game)
                .Include(t => t.Sport)
                .Where(t => t.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new CountrySession(HttpContext.Session);  
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            var cookies = new CountryCookies(Response.Cookies);
            cookies.SetMyCountryIds(countries);

            TempData["message"] = $"{model.Country.CountryName} added to favorites"; 

            return RedirectToAction("Index",   
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }












    public class FavoritesController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new OlympicListViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveSport = session.GetActiveSport(),
                Countries = session.GetMyCountries()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new CountrySession(HttpContext.Session);
            var cookies = new CountryCookies(Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite teams cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }
}