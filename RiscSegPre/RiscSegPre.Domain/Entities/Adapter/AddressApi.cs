namespace RiscSegPre.Domain.Entities.Adapter
{
    public class AddressApi
    {
        protected AddressApi() { }

        public AddressApi(string ZipCode, string PublicPlace, string Number, string Complement, string City, string Neighborhood, string State)
        {
            this.ZipCode = ZipCode;
            this.PublicPlace = PublicPlace;
            this.Number = Number;
            this.Complement = Complement;
            this.City = City;
            this.Neighborhood = Neighborhood;
            this.State = State;
        }

        public int Id { get; set; }
        public string ZipCode { get; private set; }
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string State { get; private set; }
    }
}