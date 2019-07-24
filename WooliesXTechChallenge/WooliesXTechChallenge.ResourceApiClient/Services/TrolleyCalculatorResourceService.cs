using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.ResourceInterfaces;
using WooliesXTechChallenge.Core.Models;
using WooliesXTechChallenge.ResourceApiClient.Config;
using WooliesXTechChallenge.ResourceApiClient.Helper;
using System.Net.Http;

namespace WooliesXTechChallenge.ResourceApiClient.Services
{
    public class TrolleyCalculatorResourceService : ITrolleyCalculatorResourceService
    {
        private readonly HttpHelper _httpHelper;

        public TrolleyCalculatorResourceService()
        {
            _httpHelper = new HttpHelper();
        }

        public async Task<double> GetMinimumTrolleyBalanceAsync(Trolley trolley)
        {
            var url = new Uri($"{ApiConfig.ResourceURLBase}{ApiConfig.TrolleyURLAddress}");
            var json = ResourceApiSerializer.SerializeToString(trolley);
            var httpResponse = await _httpHelper.Client.PostAsync(url,
                new StringContent(json, Encoding.UTF8, "application/json"));

            httpResponse.EnsureSuccessStatusCode();

            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                return ResourceApiSerializer.DeserializeFromString<double>(responseString);
            }

            return 0;
        }
    }
}
