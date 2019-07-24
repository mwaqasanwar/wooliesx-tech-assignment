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
    public class ProductResourceService : IProductResourceService
    {
        private readonly HttpHelper _httpHelper;

        public ProductResourceService()
        {            
            _httpHelper = new HttpHelper();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var url = new Uri($"{ApiConfig.ResourceURLBase}{ApiConfig.ProductsURLAddress}");
            var responseBody = await _httpHelper.Client.GetStringAsync(url);
            return ResourceApiSerializer.DeserializeFromString<List<Product>>(responseBody);
        }
    }
}
