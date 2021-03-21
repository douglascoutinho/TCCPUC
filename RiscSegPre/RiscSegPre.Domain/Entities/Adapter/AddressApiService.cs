namespace RiscSegPre.Domain.Entities.Adapter
{
    public class AddressApiService : IAddressApi
    {
        public AddressApi GetAddressByZipCode(string zipCode)
        {
            return new AddressApi("21831360", "Estada MAdureira", "3254", "", "Rio de Janeiro", "Madureira", "RJ");
        }
    }
}