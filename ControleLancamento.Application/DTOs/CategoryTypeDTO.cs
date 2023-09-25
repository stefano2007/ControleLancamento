﻿using System.ComponentModel.DataAnnotations;

namespace ControleLancamento.Application.DTOs;
public class CategoryTypeDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; }
    public DateTime DateCreate { get; set; }
}
