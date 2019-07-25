using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.Interface;
using WooliesXTechChallenge.Core.Models;
using WooliesXTechChallenge.Core.ResourceInterfaces;

namespace WooliesXTechChallenge.Domain.Services
{
    public class TrolleyCalculatorService : ITrolleyCalculatorService
    {
        private readonly ITrolleyCalculatorResourceService _trolleyCalculatorResourceService;
        private List<Special> _eligibleSpecials; 
        public TrolleyCalculatorService(ITrolleyCalculatorResourceService tolleyCalculatorResourceService)
        {
            _trolleyCalculatorResourceService = tolleyCalculatorResourceService;
            _eligibleSpecials = new List<Special>();
        }

        public async Task<decimal> GetMinimumTrolleyBalance(Trolley trolley)
        {
            //return await _trolleyCalculatorResourceService.GetMinimumTrolleyBalanceAsync(trolley);
            return 0.0m;
        }

        public async Task<decimal> CalculateTrolleyTotal(Trolley trolley)
        {
            _eligibleSpecials = new List<Special>();
            var products = (from p in trolley.Products
                            join q in trolley.Quantities on p.Name equals q.Name
                            select new Product { Name = p.Name, Price = p.Price, Quantity = q.Quantity }).ToList();

            if (trolley.Specials?.Count() > 0)
            {
                foreach (var special in trolley.Specials)
                {                    
                    special.FullTotal = CalculateFullTotal(special.Quantities, products);
                }

                ApplyBundeledSpecials(products, trolley);
            }

            var regularPriceProductTotal = products.Sum(p => p.Quantity * p.Price);
            var bundeledPriceProductTotal = _eligibleSpecials?.Sum(x => x.Total) ?? 0;

            return regularPriceProductTotal + bundeledPriceProductTotal;
        }

        private void ApplyBundeledSpecials(List<Product> products, Trolley trolley)
        {
            var validSpecials = new List<Special>();

            //Filter only those specials which have Total less than the full price total for bundeled products.
            var orderedSpecials = trolley.Specials.Where(x => x.Total < x.FullTotal).OrderByDescending(s => (s.FullTotal - s.Total));
            foreach (var special in orderedSpecials)
            {
                bool applySpecial = true;
                foreach (var qty in special.Quantities)
                {
                    var product = products.FirstOrDefault(x => x.Name == qty.Name);
                    if (product.Quantity < qty.Quantity)
                    {
                        applySpecial = false;
                    }
                }

                if (applySpecial)
                {
                    _eligibleSpecials.Add(special);

                    foreach (var qty in special.Quantities)
                    {
                        var product = products.FirstOrDefault(x => x.Name == qty.Name);
                        product.Quantity = product.Quantity - qty.Quantity;
                    }

                    ApplyBundeledSpecials(products, trolley);
                }
            }
        }

        private decimal CalculateFullTotal(List<Product> quantities, List<Product> products)
        {
            decimal total = 0;

            foreach (var quantity in quantities)
            {
                var price = products.First(p => p.Name.Equals(quantity.Name)).Price;
                total += price * quantity.Quantity;
            }

            return total;
        }
    }
}
