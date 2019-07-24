using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WooliesXTechChallenge.Core.Enum;
using WooliesXTechChallenge.Core.Models;

namespace WooliesXTechChallenge.Core.Interface
{
    public interface ITrolleyCalculatorService
    {
        Task<decimal> GetMinimumTrolleyBalance(Trolley trolley);

        Task<decimal> CalculateTrolleyTotal(Trolley trolley);
    }
}
