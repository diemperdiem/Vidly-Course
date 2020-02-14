using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            //var Movies = _context.Movies.ToList();
            var Movies = _context.Movies.Include(g => g.Genere).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(g => g.Genere).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MoviesFormViewModel(movie)
                { 
                    Genere = _context.Genere.ToList()
                };

                return View("MovieFormat", viewModel);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(MoviesFormViewModel mov)
        {
            if (mov.Id == 0 || mov.Id == null)
            {

                var movie = new Movie
                {
                    Id = (byte)mov.Id,
                    Name = (string)mov.Name,
                    GenereId = (byte)mov.GenereId,
                    NumberInStock = (byte)mov.NumberInStock,
                    DateAdded = System.DateTime.Now,
                    ReleaseDate = (DateTime)mov.ReleaseDate
                };

                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == mov.Id);

                movieInDb.Name = mov.Name;
                movieInDb.ReleaseDate = (DateTime)mov.ReleaseDate;
                movieInDb.Genere = (Genere)mov.Genere;
                movieInDb.NumberInStock = (byte)mov.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieFormat(int? id)
        {
            var modelView = new MoviesFormViewModel()
            {
                Genere = _context.Genere.ToList()
            };

            return View(modelView);
        }

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>()
        //    {
        //        new Movie {Id = 1, Name = "Cherk" },
        //        new Movie {Id = 2, Name = "Termineitor" }
        //    };
        //}
    }
}