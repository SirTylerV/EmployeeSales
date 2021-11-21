using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.DB;
using System;
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
    }
}
