using EmployeeSales.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Repositories
{
    public interface ICommissionRepository
    {
        Task<Commission> GetCommissionByProfitPrecent(decimal profitPrecent);
    }
}
