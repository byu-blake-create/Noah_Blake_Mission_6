using System.ComponentModel.DataAnnotations;

namespace Noah_Blake_Mission_6.Models;

public class Movie
{
    public int MovieId { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; } = string.Empty;

    [Required]
    public string Rating { get; set; } = string.Empty;

    public bool? Edited { get; set; }

    public string? LentTo { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }
}
