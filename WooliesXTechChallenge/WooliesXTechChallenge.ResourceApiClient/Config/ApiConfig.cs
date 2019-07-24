using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesXTechChallenge.ResourceApiClient.Config
{
    public class ApiConfig
    {
        public const string ResourceURLBase = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/";
        public const string ApiToken = "a0d7b928-0764-4607-b908-ab3462efad75";

        public static readonly string ProductsURLAddress = $"products?token={ApiToken}";
        public static readonly string ShoppingHistoryURLAddress = $"shopperHistory?token={ApiToken}";
        public static readonly string TrolleyURLAddress = $"trolleyCalculator?token={ApiToken}";
    }
}
