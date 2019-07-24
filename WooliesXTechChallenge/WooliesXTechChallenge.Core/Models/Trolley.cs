using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesXTechChallenge.Core.Models
{    
    public class Trolley
    {
        [JsonProperty("products")] 
        public List<Product> Products { get; set; }
        [JsonProperty("quantities")]
        public List<Product> Quantities { get; set; }
        [JsonProperty("specials")] 
        public List<Special> Specials { get; set; }
    }
}
