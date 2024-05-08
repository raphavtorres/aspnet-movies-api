using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class Movie
{
  [Key]
  [Required]
  public int Id { get; set; }

  [Required(ErrorMessage = "Movie title is required")]
  [StringLength(100, ErrorMessage = "Title must have at most 100 chacters")]
  public string Title { get; set; }

  [Required(ErrorMessage = "Movie genre is required")]
  [MaxLength(50, ErrorMessage = "Genre size cannot exceed 50 chacters")]
  public string Genre { get; set; }

  [Required]
  [Range(70, 600, ErrorMessage = "Duration must have between 70 and 600 minutes")]
  public int Duration { get; set; }
}