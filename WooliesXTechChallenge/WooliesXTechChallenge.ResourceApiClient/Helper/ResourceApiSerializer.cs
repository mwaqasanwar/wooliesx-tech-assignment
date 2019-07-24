using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesXTechChallenge.ResourceApiClient.Helper
{
    public class ResourceApiSerializer
    {
        public static T DeserializeFromString<T>(string json)
        {
            //provide you deserializer
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string SerializeToString<T>(T data)
        {
            //provide your serializer
            return JsonConvert.SerializeObject(data);
        }
    }
}
