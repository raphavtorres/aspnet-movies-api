using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
  public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
  {
    return _mapper.Map<List<ReadMovieDto>>(
      _movieContext.Movies.Skip(skip).Take(take)
    );
  }

  [HttpGet("{id}")]
  public IActionResult GetMovieById(int id)
  {
    Movie? movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null) return NotFound();

    ReadMovieDto readMovieDto = _mapper.Map<ReadMovieDto>(movie);
    return Ok(readMovieDto);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
  {
    Movie? movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null) return NotFound();
    _mapper.Map(updateMovieDto, movie);
    _movieContext.SaveChanges();
    return NoContent();
  }

  [HttpPatch("{id}")]
  public IActionResult UpdateMoviePartial(int id, JsonPatchDocument<UpdateMovieDto> patchDocument)
  {
    Movie? movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null) return NotFound();

    UpdateMovieDto updateMovieDto = _mapper.Map<UpdateMovieDto>(movie);

    patchDocument.ApplyTo(updateMovieDto, ModelState);

    if(!TryValidateModel(updateMovieDto))
    {
      return ValidationProblem(ModelState);
    }

    _mapper.Map(updateMovieDto, movie);
    _movieContext.SaveChanges();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteMovie(int id)
  {
    Movie? movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null) return NotFound();

    _movieContext.Remove(movie);
    _movieContext.SaveChanges();
    return NoContent();
  }
}