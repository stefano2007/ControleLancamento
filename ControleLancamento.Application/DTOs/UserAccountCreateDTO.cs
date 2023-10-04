using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs
{
    public class UserAccountCreateDTO
    {
        [Required(ErrorMessage = "The AccountId is Required")]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "The UserId is Required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "The IsUserMain is Required")]
        public bool IsUserMain { get; set; }
    }
}
