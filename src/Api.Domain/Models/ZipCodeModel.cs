using System;
namespace Api.Domain.Models
{
    public class ZipCodeModel : BaseModel
    {
        public string ZipCode { get; set;}
        public string PublicPlace { get; set;}
        private string _number;
        public string Number
        {     
            get { return _number; } 
            set { Number = string.IsNullOrEmpty(value) ? "S/N" : value; }
        }
        public Guid CountyId{ get; set;}
    }
}