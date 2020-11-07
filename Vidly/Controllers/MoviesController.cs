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

    }
}
