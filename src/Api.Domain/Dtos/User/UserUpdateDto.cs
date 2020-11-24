using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "O id é um campo obrigatório")]
        public Guid Id { get; set; }
 
        [Required(ErrorMessage = "O nome é obrigatório para o login")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
 
        [Required(ErrorMessage = "O e-mail é obrigatório para o login")]
        [EmailAddress(ErrorMessage = "E-mail em formato invalído")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
 
        public string Email { get; set; }
 
        public DateTime UpdateAt { get; set; }
    }
}