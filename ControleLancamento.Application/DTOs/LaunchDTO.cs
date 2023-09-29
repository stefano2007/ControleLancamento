using ControleLancamento.Domain.Entities.Enum;

namespace ControleLancamento.Application.DTOs
{
    public class LaunchDTO
    {
        public int Id { get; set; }
        public LaunchType LaunchType { get; set; }
        public CategoryDTO Category { get; set; }
        public AccountDTO Account { get; set; }
        public string Description { get; set; }
        public DateOnly DateLaunch { get; set; }
        public decimal Price { get; set; }
        public string Observation { get; set; }
        public string Tag { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
