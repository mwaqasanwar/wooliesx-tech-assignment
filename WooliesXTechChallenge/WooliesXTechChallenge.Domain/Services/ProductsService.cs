using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.Enum;
using WooliesXTechChallenge.Core.Interface;
using WooliesXTechChallenge.Core.Models;
using WooliesXTechChallenge.Core.ResourceInterfaces;

namespace WooliesXTechChallenge.Domain.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductResourceService _productResourceService;
        private readonly IShoppingHistoryResourceService _shoppingHistoryResourceService;

        public ProductsService(IProductResourceService productResourceService, IShoppingHistoryResourceService shoppingHistoryResourceService)
        {
            _productResourceService = productResourceService;
            _shoppingHistoryResourceService = shoppingHistoryResourceService;
        }

        public async Task<List<Product>> SortProductsAsync(SortOptions sortOption)
        {
            var products = await _productResourceService.GetProductsAsync();
            switch (sortOption)
            {
                case SortOptions.Low:
                    return products.OrderBy(x => x.Price).ToList();
                case SortOptions.High:
                    return products.OrderByDescending(x => x.Price).ToList();
                case SortOptions.Ascending:
                    return products.OrderBy(x => x.Name).ToList();
                case SortOptions.Descending:
                    return products.OrderByDescending(x => x.Name).ToList();
                case SortOptions.Recommended:
                    return await GetRecommendedProductsByQuantitySold(products);
                default:
                    return products.ToList();
            }
        }

        private async Task<List<Product>> GetRecommendedProductsByQuantitySold(List<Product> availableProducts)
        {
            var recommendedOrderedList = new List<Product>();

            var shopperHistoryProducts = await _shoppingHistoryResourceService.GetShoppingHistoryAsync();
            var mostSoldProducts = shopperHistoryProducts.SelectMany(x => x.Products)
                                                 .GroupBy(x => x.Name)
                                                 .Select(
                                                        g => new Product()
                                                        {
                                                            Name = g.First().Name,
                                                            Quantity = g.Sum(p => p.Quantity)
                                                        })
                                                .OrderByDescending(x => x.Quantity)
                                                .ToList();

            foreach (var rp in mostSoldProducts)
            {
                recommendedOrderedList.Add(availableProducts.Where(p => p.Name == rp.Name).First());
            }

            //Add all remaining products which are not in the mostSoldProducts list.
            foreach (var product in availableProducts)
            {
                if (!recommendedOrderedList.Any(s => s.Name.Contains(product.Name)))
                {
                    recommendedOrderedList.Add(product);
                }
            }

            return recommendedOrderedList;
        }
    }
}
