using System;

namespace Api.Domain.Models
{
    public class CountyModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _codeIbge;
        public int CodeIbge
        {
            get { return _codeIbge; }
            set { _codeIbge = value; }
        }
        private Guid _federalUnitId;
        public Guid FederalUnitId
        {
            get { return _federalUnitId; }
            set { _federalUnitId = value; }
        }
    }
}