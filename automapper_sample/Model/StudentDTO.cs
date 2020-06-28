using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace automapper_sample.Model
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [JsonProperty("City")]
        public string CurrentCity { get; set; }
        public AddressDTO Address { get; set; }

    }
}
