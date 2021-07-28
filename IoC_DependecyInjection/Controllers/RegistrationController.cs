using IoC_DependecyInjection.Business;
using IoC_DependecyInjection.Interfaces.Services;
using IoC_DependecyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IoC_DependecyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationBusiness _registrationBusiness;
      

        public RegistrationController(IRegistrationBusiness registrationBusiness)
        {
            _registrationBusiness = registrationBusiness;
        }

        [HttpGet]
        [Route("{zipCode}")]
        public async Task<IActionResult> GetAddressFromZipCode([FromRoute] string zipCode)
        {

                   
            string address = await _registrationBusiness.GetAddressFromZipCode(zipCode);
            int registratioBusinessCounter = _registrationBusiness.GetCounter();

            return Ok(new { 
                address,
                registratioBusinessCounter
            });
        }

    }
}
