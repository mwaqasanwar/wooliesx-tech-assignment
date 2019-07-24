using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.ResourceInterfaces;
using WooliesXTechChallenge.Core.Models;
using WooliesXTechChallenge.ResourceApiClient.Config;
using WooliesXTechChallenge.ResourceApiClient.Helper;

namespace WooliesXTechChallenge.ResourceApiClient.Services
{
    public class ShoppingHistoryResourceService : IShoppingHistoryResourceService
    {
        private readonly HttpHelper _httpHelper;

        public ShoppingHistoryResourceService()
        {
            _httpHelper = new HttpHelper();
        }

        public async Task<List<ShoppingHistory>> GetShoppingHistoryAsync()
        {
            var url = new Uri($"{ApiConfig.ResourceURLBase}{ApiConfig.ShoppingHistoryURLAddress}");
            var responseBody = await _httpHelper.Client.GetStringAsync(url);
            return ResourceApiSerializer.DeserializeFromString<List<ShoppingHistory>>(responseBody);
        }
    }
}
