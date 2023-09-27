using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs
{
    public class AccountTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
