using System;
namespace Api.Domain.Dtos.County
{
    public class CountyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodeIbge { get; set; }
        public Guid FederalUnitId { get; set; }
    }
}