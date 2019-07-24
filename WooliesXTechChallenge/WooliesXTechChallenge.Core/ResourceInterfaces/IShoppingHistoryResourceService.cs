using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.Models;

namespace WooliesXTechChallenge.Core.ResourceInterfaces
{
    public interface IShoppingHistoryResourceService
    {
        Task<List<ShoppingHistory>> GetShoppingHistoryAsync();
    }
}
