using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
     
            return await _context.Movies
                .Select(movie => Mapper.Map<Movie, MovieDto>(movie))
                .ToListAsync().ConfigureAwait(true);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id).ConfigureAwait(true);

            if (movie == null)
            {
                return NotFound();
            }
            return Mapper.Map<Movie, MovieDto>(movie);
        }

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie(MovieDto movieDto)
        {

            if (!ModelState.IsValid)
                return NotFound();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movieDto.GenreId = movie.GenreId;

            _context.Movies.Add(movie);

            await _context.SaveChangesAsync().ConfigureAwait(true);

            movieDto.Id = movie.Id;

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDto>> DeleteMovie(int id)
        {
            var movie = await _context.Movies.SingleAsync(m =>m.Id==id).ConfigureAwait(true);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync().ConfigureAwait(true);

            return Mapper.Map<Movie, MovieDto>(movie);
        }


        //// PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return BadRequest();
            }

            var movie = await _context.Movies.FindAsync(id).ConfigureAwait(true);
            
            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movie);
            movieDto.GenreId = movie.GenreId;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(true);
            }
            catch (DbUpdateConcurrencyException) when (!MovieExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool MovieExists(int id) =>
            _context.Customers.Any(e => e.Id == id);
    }
}
