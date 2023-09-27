using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email is Required")]
        [EmailAddress]
        [MaxLength(120)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [MinLength(3)]
        [MaxLength(60)]
        public string Password { get; set; }

        [MaxLength(60)]
        public string Occupation { get; set; }

        [MaxLength(11)]
        public string CellPhone { get; set; }
    }
}
