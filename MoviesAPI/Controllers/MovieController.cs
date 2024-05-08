using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController
{

  private static List<Movie> movies = new List<Movie>();
  private static int id = 0;

  [HttpPost]
  public IActionResult AddMovie([FromBody] Movie movie) 
  {
    movie.Id = id++;
    movies.Add(movie);
    return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id});
  }

  [HttpGet]
  public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
  {
    return movies.Skip(skip).Take(take);
  }

  [HttpGet("{id}")]
  public IActionResult GetMovieById(int id)
  {
    var movie = movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null) return NotFound();
    return Ok(movie);
  }
}