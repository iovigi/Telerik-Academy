using MovieSystem.Data.Models;
using MovieSystem.Data.UnitsOfWork;
using MovieSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IUnitOfWork UnitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var result = UnitOfWork.Get<Movie>().All().Select(MovieViewModel.From).ToList();

            return View(result);
        }

        public ActionResult Insert(MovieViewModel movieViewModel)
        {
            UnitOfWork.Get<Movie>().Add(movieViewModel.To);
            UnitOfWork.SaveChanges();

            var result = UnitOfWork.Get<Movie>().All().Select(MovieViewModel.From).ToList();

            if(Request.IsAjaxRequest())
            {
                return PartialView("_ListMovies", result);
            }

            return View("Index", result);
        }

        public ActionResult Delete(int id)
        {
            UnitOfWork.Get<Movie>().Delete(id);
            UnitOfWork.SaveChanges();

            var result = UnitOfWork.Get<Movie>().All().Select(MovieViewModel.From).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListMovies", result);
            }

            return View("Index", result);
        }

    }
}