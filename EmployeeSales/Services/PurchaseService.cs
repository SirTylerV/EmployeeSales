using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.DB;
using EmployeeSales.Models.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ICommissionService _commissionService;
        private readonly IProductService _productService;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(
            ICommissionService commissionService,
            IProductService productService,
            IPurchaseRepository purchaseRepository
            )
        {
            _commissionService = commissionService;
            _productService = productService;
            _purchaseRepository = purchaseRepository;
        }

        public async Task CreatePurchase(Purchase purchase)
        {
            // Get the product for the wholesale
            var product = await _productService.GetProduct(purchase.ProductId);
            // Get the commission commission record that this sale is eligiable for
            var commission = await _commissionService.GetCommissionByProfit(product.Wholesale, purchase.SalePrice);
            // Make the calculations
            purchase.CommissionId = commission.Id;
            purchase.CommissionMade = purchase.SalePrice * commission.Percent;
            // Fill in the last things we need
            purchase.CreatedAt = DateTime.UtcNow;
            // Add the the DB
            await _purchaseRepository.CreatePurchase(purchase);
        }

        public List<BasePurchaseModel> GetPurchases(string direction, string property)
        {
            var purchases = _purchaseRepository.GetAllPurchases()
                .Select(p => new BasePurchaseModel()
                {
                    Id = p.Id,
                    CreatedAt = p.CreatedAt,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    Wholesale = p.Product.Wholesale,
                    SalePrice = p.SalePrice,
                    CommissionMade = p.CommissionMade
                });
            return SortPurchaseList(purchases, direction, property);
        }

        public List<BasePurchaseModel> SortPurchaseList(IEnumerable<BasePurchaseModel> purchases, string direction, string property)
        {
            switch (property)
            {
                case "name":
                    return (direction == "asc" ? purchases.OrderBy(s => s.ProductName) : purchases.OrderByDescending(s => s.ProductName)).ToList();
                case "date":
                    return (direction == "asc" ? purchases.OrderBy(s => s.CreatedAt) : purchases.OrderByDescending(s => s.CreatedAt)).ToList();
                case "wholesale":
                    return (direction == "asc" ? purchases.OrderBy(s => s.Wholesale) : purchases.OrderByDescending(s => s.Wholesale)).ToList();
                case "salePrice":
                    return (direction == "asc" ? purchases.OrderBy(s => s.SalePrice) : purchases.OrderByDescending(s => s.SalePrice)).ToList();
                default:
                    return (direction == "asc" ? purchases.OrderBy(s => s.ProductName) : purchases.OrderByDescending(s => s.ProductName)).ToList();
            }
        }
    }
}
