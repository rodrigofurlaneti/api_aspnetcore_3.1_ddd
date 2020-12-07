using System;
using Api.Domain.Dtos.FederalUnit;
namespace Api.Domain.Dtos.County
{
    public class CountyCompleteDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodeIbge { get; set; }
        public Guid FederalUnitId { get; set; }
        public FederalUnitDto FederalUnit { get; set; }
    }
}