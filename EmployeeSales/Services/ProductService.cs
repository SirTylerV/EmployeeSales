using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        public ProductService(
            IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetProduct(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAllProducts()
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id);
        }
    }
}
