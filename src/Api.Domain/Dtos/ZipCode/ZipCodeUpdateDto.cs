using System;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeUpdateDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Cep é um campo obrigatório.")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Lograduro é um campo obrigatório.")]
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        [Required(ErrorMessage = "Município é um campo obrigatório.")]
        public Guid CountyId { get; set; }
    }
}