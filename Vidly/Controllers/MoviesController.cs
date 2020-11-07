using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie() {Name = "Shark!"};
            // return View(movie);
            // return Content("Hello World!"); // We get a plain string content in the response
            // return NotFound();  // standard 404 error
            // return new EmptyResult();
            return RedirectToAction("Index", "Home", new {page=1,sortBy="name"});
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" +id);
        }

        //movies
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")] // route attribute && constraint regex(\\d{4})
        public IActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}
