using System;
namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeCreateResultDto
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public Guid CountyId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}