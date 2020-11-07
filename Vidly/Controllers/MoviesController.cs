using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Films.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Films.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie() {Name = "Shark!"};
            return View(movie);
           
        } 
    }
}
