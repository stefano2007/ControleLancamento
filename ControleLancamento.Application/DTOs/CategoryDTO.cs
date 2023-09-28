namespace ControleLancamento.Application.DTOs;
public class CategoryDTO
{
    public int Id { get; set; }
    public CategoryTypeDTO CategoryType { get; set; }
    public string Name { get; set; }
    public string? Color { get; set; }
    public string? Icon { get; set; }
    public DateTime DateCreate { get; set; }
}
