using EmployeeSales.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface ICommissionService
    {
        Task<Commission> GetCommissionByProfit(decimal wholeSale, decimal salePrice);
    }
}
