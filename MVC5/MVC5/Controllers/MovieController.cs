using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC5.Models;
using MVC5.ViewModels;

namespace MVC5.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _content;

        public MovieController()
        {
            _content = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _content.Dispose();
        }

        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie {Name = "Endgame"};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("movie/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Movies()
        {
            var movies = _content.Movies.Include(a => a.Genre).ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movieDetail = _content.Movies.Include(a => a.Genre).First(a => a.Id == id);
            return View(movieDetail);
        }

        public ActionResult New()
        {
            var genre = _content.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _content.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _content.Movies.Single(a => a.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _content.SaveChanges();

            return RedirectToAction("Movies", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _content.Movies.SingleOrDefault(a => a.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _content.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}