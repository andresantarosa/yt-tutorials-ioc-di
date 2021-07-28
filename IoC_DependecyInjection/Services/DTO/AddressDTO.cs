using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoC_DependecyInjection.Services.DTO
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string Uf { get; set; }
        public string ZipCode { get; set; }
        public object City { get; internal set; }
    }
}
