using EmployeeSales.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        IEnumerable<Product> GetProducts();
    }
}
