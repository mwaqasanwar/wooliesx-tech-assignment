using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.Enum;
using WooliesXTechChallenge.Core.Models;

namespace WooliesXTechChallenge.Core.Interface
{
    public interface IProductsService
    {
        Task<List<Product>> SortProductsAsync(SortOptions sortOption);
    }
}
