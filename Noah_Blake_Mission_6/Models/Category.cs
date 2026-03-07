using System.ComponentModel.DataAnnotations;

namespace Noah_Blake_Mission_6.Models;

public class Category
{
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = string.Empty;

    public List<Movie> Movies { get; set; } = [];
}
