using System;

namespace Api.Domain.Models
{
    public class ZipCodeModel
    {
        private string _zipCode;
        public string ZipCode
        {     
            get { return _zipCode; } 
            set { ZipCode = value;}
        }
        private string _publicPlace;
        public string PublicPlace
        {     
            get { return _publicPlace; } 
            set { PublicPlace = value;}
        }
        private string _number;
        public string Number
        {     
            get { return _number; } 
            set { Number = string.IsNullOrEmpty(value) ? "S/N" : value; }
        }
        private Guid _countyId;
        public Guid CountyId
        {     
            get { return _countyId; } 
            set { CountyId = value;}
        }
    }
}