using System.ComponentModel.DataAnnotations;

namespace Noah_Blake_Mission_6.Models;

public class Movie
{
    public int MovieId { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int? CategoryId { get; set; }

    public Category? Category { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Range(1888, 3000)]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; } = string.Empty;

    [Required]
    [RegularExpression("G|PG|PG-13|R", ErrorMessage = "Rating must be G, PG, PG-13, or R.")]
    public string Rating { get; set; } = string.Empty;

    public bool? Edited { get; set; }

    [Required]
    [Display(Name = "Copied To Plex")]
    public bool? CopiedToPlex { get; set; }

    public string? LentTo { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }
}
