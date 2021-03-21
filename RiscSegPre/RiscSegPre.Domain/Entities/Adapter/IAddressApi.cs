using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities.Adapter
{
    public interface IAddressApi
    {
        AddressApi GetAddressByZipCode(string zipCode);
    }
}