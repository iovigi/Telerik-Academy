using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameWorld.Web.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult ArcadeList()
        {
            List<string> games = new List<string>();
            games.Add("Infection");
            games.Add("007: Nightfire");
            games.Add("007: Quantum of Solace");
            games.Add("10 Pin: Champions Alley");
            games.Add("10,000 Bullets ");
            games.Add("187 Ride or Die");

            return View(games);
        }

        public ActionResult HorrorList()
        {
            List<string> games = new List<string>();
            games.Add("Alien");
            games.Add("Akai Ito");
            games.Add("7 Days To Die");
            games.Add("Alan Wake");
            games.Add("Alone in the Dark");
            games.Add("Amy");

            return View(games);
        }
    }
}