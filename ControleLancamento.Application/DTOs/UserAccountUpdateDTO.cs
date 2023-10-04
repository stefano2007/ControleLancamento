using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs
{
    public class UserAccountUpdateDTO
    {
        [Required(ErrorMessage = "The Id is Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The AccountId is Required")]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "The UserId is Required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "The IsUserMain is Required")]
        public bool IsUserMain { get; set; }
    }
}
