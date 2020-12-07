using System;
namespace Api.Domain.Dtos.FederalUnit
{
    public class FederalUnitDto
    {
        public Guid Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
    }
}