using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly ICommissionRepository _commissionRepository;
        public CommissionService(
            ICommissionRepository commissionRepository
            )
        {
            _commissionRepository = commissionRepository;
        }
        public async Task<Commission> GetCommissionByProfit(decimal wholeSale, decimal salePrice)
        {
            // Calculating the percent profit as decimal
            var profit = salePrice > wholeSale
                ? (salePrice - wholeSale) / wholeSale
                : 0;
            // If they are over 99% profit just cap it there
            decimal cap = (decimal)0.99; 
            profit = profit <= cap ? profit : cap;
            return await _commissionRepository.GetCommissionByProfitPrecent(profit);
        }
    }
}
