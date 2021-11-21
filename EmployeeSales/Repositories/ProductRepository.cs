using EmployeeSales.Data;
using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EmployeeSalesDbContext _db;

        public ProductRepository(
            EmployeeSalesDbContext db
            )
        {
            _db = db;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Product;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
