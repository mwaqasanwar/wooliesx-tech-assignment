using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesXTechChallenge.Core.Models
{
    public class ShoppingHistory
    {
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}
