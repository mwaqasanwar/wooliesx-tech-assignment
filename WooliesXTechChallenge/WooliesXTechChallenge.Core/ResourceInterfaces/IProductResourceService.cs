using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.Models;

namespace WooliesXTechChallenge.Core.ResourceInterfaces
{
    public interface IProductResourceService
    {
        Task<List<Product>> GetProductsAsync();
    }
}
