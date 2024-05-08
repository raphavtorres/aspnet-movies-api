using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

  private MovieContext _movieContext;
  private IMapper _mapper;

  public MovieController(MovieContext movieContext, IMapper mapper)
  {
    _movieContext = movieContext;
    _mapper = mapper;
  }


  [HttpPost]
  public IActionResult AddMovie([FromBody] CreateMovieDto movieDto) 
  {
    Movie movie = _mapper.Map<Movie>(movieDto);
    _movieContext.Movies.Add(movie);
    _movieContext.SaveChanges();

    return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id}, movie);
  }

  [HttpGet]
  public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
  {
    return _movieContext.Movies.Skip(skip).Take(take);
  }

  [HttpGet("{id}")]
  public IActionResult GetMovieById(int id)
  {
    var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null) return NotFound();
    return Ok(movie);
  }
}