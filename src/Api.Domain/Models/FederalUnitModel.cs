namespace Api.Domain.Models
{
    public class FederalUnitModel
    {
        private string _initials;
        public string Initials
        {
            get { return _initials;}
            set { _initials = Initials;}
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}