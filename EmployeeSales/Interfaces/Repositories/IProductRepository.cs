using EmployeeSales.Models.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Task<Product> GetProduct(int id);
    }
}
