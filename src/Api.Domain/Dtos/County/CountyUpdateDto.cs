using System;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Dtos.County
{
    public class CountyUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome do município é obridatório")]
        [StringLength(60, ErrorMessage = "O nome do município deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE está inválido.")]
        public int CodeIbge { get; set; }
        [Required(ErrorMessage = "Código do UF é um campo obrigatório.")]
        public Guid FederalUnitId { get; set; }
    }
}