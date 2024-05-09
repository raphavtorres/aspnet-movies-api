using AutoMapper;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

class MovieProfile : Profile
{
  public MovieProfile()
  {
    CreateMap<CreateMovieDto, Movie>();
    CreateMap<UpdateMovieDto, Movie>();
    CreateMap<Movie, UpdateMovieDto>();
    CreateMap<Movie, ReadMovieDto>();
  }
}