using IoC_DependecyInjection.Interfaces.Services;
using IoC_DependecyInjection.Services.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IoC_DependecyInjection.Services
{
   public class ViaCepServices : IZipCodeServices
    {

        private int counter;

        public ViaCepServices()
        {
            counter = 0;
        }
        public async Task<AddressDTO> GetAddressFromZipCode(string zipCode)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{zipCode}/json/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseBody))
                return null;

            var addressInfo = JsonConvert.DeserializeObject<ViaCepResponse>(responseBody);

            counter++;

            return new AddressDTO
            {
                Street = addressInfo.logradouro,
                District = addressInfo.bairro,
                City = addressInfo.localidade,
                Uf = addressInfo.uf,
                ZipCode = addressInfo.cep
            };

        }

        public int GetCounter()
        {
            return counter;
        }

        public class ViaCepResponse
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string ibge { get; set; }
            public string gia { get; set; }
            public string ddd { get; set; }
            public string siafi { get; set; }
        }
    }
}
