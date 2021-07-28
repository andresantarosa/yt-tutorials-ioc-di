using IoC_DependecyInjection.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoC_DependecyInjection.Interfaces.Services
{
    public interface IZipCodeServices
    {
        Task<AddressDTO> GetAddressFromZipCode(string zipCode);
        int GetCounter();
    }
}
