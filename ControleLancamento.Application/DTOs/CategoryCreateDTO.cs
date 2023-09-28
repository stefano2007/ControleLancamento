using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs;
public class CategoryCreateDTO
{
    [Required(ErrorMessage = "The CategoryTypeId is Required")]
    public int CategoryTypeId { get; set; }
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; }
    public string? Color { get; set; }
    public string? Icon { get; set; }
}
