using ControleLancamento.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs
{
    public class LaunchUpdateDTO
    {
        [Required(ErrorMessage = "The Id is Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The LaunchType is Required")]
        public LaunchType LaunchType { get; set; }
        [Required(ErrorMessage = "The Email is Required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "The CategoryId is Required")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "The AccountId is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The DateLaunch is Required")]
        public DateTime DateLaunch { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Range(0, 9999999)]
        public decimal Price { get; set; }
        [MaxLength(250)]
        public string? Observation { get; set; }

        [MaxLength(20)]
        public string? Tag { get; set; }
    }
}
