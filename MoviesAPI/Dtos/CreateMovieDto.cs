using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Dtos;

public class CreateMovieDto
{

  [Required(ErrorMessage = "Movie title is required")]
  [StringLength(100, ErrorMessage = "Title must have at most 100 chacters")]
  public string Title { get; set; }

  [Required(ErrorMessage = "Movie genre is required")]
  [StringLength(50, ErrorMessage = "Genre size cannot exceed 50 chacters")]
  public string Genre { get; set; }

  [Required]
  [Range(70, 600, ErrorMessage = "Duration must have between 70 and 600 minutes")]
  public int Duration { get; set; }
}