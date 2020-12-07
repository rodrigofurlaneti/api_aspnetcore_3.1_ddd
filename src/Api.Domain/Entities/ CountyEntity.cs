using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Entities
{
    public class  CountyEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public int CodeIbge { get; set; }
        [Required]
        [MaxLength(2)]
        public Guid UfId { get; set; }
        public FederalUnitEntity FederalUnit { get; set; }
        public IEnumerable<ZipCodeEntity> ZipCodes { get; set; }
    }
}