using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var movies = _context.Movies.Include(g => g.Genre).ToList();
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _context.Movies.Include(g => g.Genre).SingleOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(true);
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound(404);

            var viewModel = new MovieFormViewModel(movie)
            {
                // We initialize this lines in the movieViewModel constructor 
                //Id = movie.Id,
                //Name = movie.Name,
                //ReleaseDate = movie.ReleaseDate,
                //GenreId = movie.GenreId,
                //NumberInStock = movie.NumberInStock,
                Genres = _context.Genres.ToList(),

            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {

                var modelView = new MovieFormViewModel(movie)
                {   // to avoid the Id error we instantiate a new Movie object
                    // and add a Hidden method to MovieForm.cshtml
                    // Movie = movie,

                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", modelView);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult New()
        {

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
  
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }
    }

}
