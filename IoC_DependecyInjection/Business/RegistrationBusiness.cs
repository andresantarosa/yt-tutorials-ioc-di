using IoC_DependecyInjection.Interfaces.Services;
using IoC_DependecyInjection.Services;
using System.Threading.Tasks;

namespace IoC_DependecyInjection.Business
{
    public interface IRegistrationBusiness
    {
        Task<string> GetAddressFromZipCode(string zipCode);
        int GetCounter();
    }

    public class RegistrationBusiness : IRegistrationBusiness
    {
        private readonly IZipCodeServices _zipCodeServices;

        public RegistrationBusiness(IZipCodeServices zipCodeServices)
        {
            _zipCodeServices = zipCodeServices;
        }

        public async Task<string> GetAddressFromZipCode(string zipCode)
        {

            var cepInfo = await _zipCodeServices.GetAddressFromZipCode(zipCode);
            return $"{cepInfo.Street} - {cepInfo.District} - {cepInfo.City}/{cepInfo.Uf}";
        }

        public int GetCounter()
        {
            return _zipCodeServices.GetCounter();
        }
    }
}
