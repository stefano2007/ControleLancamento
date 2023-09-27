using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs
{
    public class AccountTypeCreateDTO
    {
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
