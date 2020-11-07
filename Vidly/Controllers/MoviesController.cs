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
        //GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie() {Name = "Shark!"};

            // ViewData["Movie"] = movie; // view data dictionary
            // ViewBag.Movie = movie;// instead of using viewData with magic string we use viewBag with magic property
            return View(movie);
        }

       
    }
}
