using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesXTechChallenge.Core.Models
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
