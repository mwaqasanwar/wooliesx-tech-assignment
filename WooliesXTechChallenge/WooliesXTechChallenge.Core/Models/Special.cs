using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesXTechChallenge.Core.Models
{
    public class Special
    {
        [JsonProperty("quantities")]
        public List<Product> Quantities { get; set; }

        public decimal Total { get; set; }

        public decimal FullTotal { get; set; }
    }
}