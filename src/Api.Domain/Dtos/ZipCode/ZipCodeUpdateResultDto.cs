using System;
namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeUpdateResultDto
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public Guid CountyId { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}