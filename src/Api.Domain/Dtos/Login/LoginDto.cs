using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Login.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório para o login")]
        [EmailAddress(ErrorMessage = "E-mail em formato invalído")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email{ get; set;}
    }
}