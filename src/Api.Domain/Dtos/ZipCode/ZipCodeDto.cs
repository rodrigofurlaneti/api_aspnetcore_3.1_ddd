using System;
using Api.Domain.Dtos.County;
namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDto
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public Guid CountyId { get; set; }
        public CountyCompleteDto County { get; set; }
    }
}