using IoC_DependecyInjection.Interfaces.Services;
using IoC_DependecyInjection.Services.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IoC_DependecyInjection.Services
{

    public class ApiCepServices : IZipCodeServices
    {
        private int counter;

        public ApiCepServices()
        {
            counter = 0;
        }
        
        public int GetCounter()
        {
            return counter;
        }

        public async Task<AddressDTO> GetAddressFromZipCode(string zipCode)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://ws.apicep.com/cep/{zipCode}.json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseBody))
                return null;

            var addressInfo = JsonConvert.DeserializeObject<ApiCepResponse>(responseBody);

            counter++;

            return new AddressDTO
            {
                Street = addressInfo.address,
                City = addressInfo.city,
                District = addressInfo.district,
                Uf = addressInfo.state,
                ZipCode = addressInfo.code
            };
        }

        public class ApiCepResponse
        {
            public int status { get; set; }
            public bool ok { get; set; }
            public string code { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string address { get; set; }
            public string statusText { get; set; }
        }
    }
}
