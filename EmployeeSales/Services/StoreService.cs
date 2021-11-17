using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.Employee;
using EmployeeSales.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Services
{
    public class StoreService : IStoreService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IStoreRepository _storeRepository;

        public StoreService(
            IEmployeeRepository employeeRepository,
            IPurchaseRepository purchaseRepository,
            IStoreRepository storeRepository
            )
        {
            _employeeRepository = employeeRepository;
            _purchaseRepository = purchaseRepository;
            _storeRepository = storeRepository;
        }

        public List<StoreListModel> GetStores(string direction, string property)
        {
            return SortStoreList(_storeRepository.GetStoreListData(), direction, property);
        }

        public async Task<StoreViewModel> GetStoreView(int storeId)
        {
            // Get date one year in the past
            var yearAgo = DateTime.UtcNow.AddYears(-1);

            // Getting all the employess of the store
            var employees = _employeeRepository.GetEmployeesByStore(storeId);
            // Grabbing all the purchaes of the past years 
            var purchases = _purchaseRepository.GetPurchasesAfterDate(yearAgo)
                .Join(employees,
                        purchase => purchase.EmployeeId,
                        employee => employee.Id,
                        (purchase, employee) => purchase);

            // Grabbing the store view and leveraging the queries above
            var s = await _storeRepository.GetStore(storeId);
            var storeView = new StoreViewModel()
            {
                Id = s.Id,
                State = s.State,
                StoreName = s.StoreName,
                Street = s.Street,
                ZipCode = s.ZipCode,
                Employees = employees
                    .Select(e => new EmployeeListModel()
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        StoreId = e.StoreId,
                        EmploymentStatus = e.EmploymentStatus.StatusName,
                        GrossCommission = purchases
                            .Where(p => p.EmployeeId == e.Id)
                            .Sum(p => p.CommissionMade)
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList(),
            };

            // Filling in some profit information
            storeView.GrossYearlyProfit = purchases.Sum(p => p.SalePrice);
            storeView.InventoryCost = purchases.Sum(p => p.Product.Wholesale);
            storeView.YearlyProfit = storeView.GrossYearlyProfit - storeView.InventoryCost - storeView.Employees.Sum(e => e.GrossCommission);

            return storeView;
        }

        public List<StoreListModel> SortStoreList(IEnumerable<StoreListModel> stores, string direction, string property)
        {
            switch (property)
            {
                case "name":
                    return (direction == "asc" ? stores.OrderBy(s => s.StoreName) : stores.OrderByDescending(s => s.StoreName)).ToList();
                case "state":
                    return (direction == "asc" ? stores.OrderBy(s => s.State) : stores.OrderByDescending(s => s.State)).ToList();
                case "grossPay":
                    return (direction == "asc" ? stores.OrderBy(s => s.GrossYearlyProfit) : stores.OrderByDescending(s => s.GrossYearlyProfit)).ToList();
                default:
                    return (direction == "asc" ? stores.OrderBy(s => s.StoreName) : stores.OrderByDescending(s => s.StoreName)).ToList();
            }
        }
    }
}
