using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.Employee;
using EmployeeSales.Models.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IPurchaseRepository purchaseRepository
            )
        {
            _employeeRepository = employeeRepository;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<BaseEmployeeModel> GetBaseEmployee(int id)
        {
            var e = await _employeeRepository.GetEmployee(id);
            return new BaseEmployeeModel()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                StoreId = e.StoreId,
                EmploymentStatus = e.EmploymentStatus.StatusName
            };
        }

        public List<BaseEmployeeModel> GetEmployees(string direction, string property)
        {
            var date = DateTime.UtcNow.AddYears(-1);

            var purchases = _purchaseRepository.GetPurchasesAfterDate(date);
            var employeeList = _employeeRepository.GetEmployees()
                .Select(e => new BaseEmployeeModel()
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    StoreId = e.StoreId,
                    EmploymentStatus = e.EmploymentStatus.StatusName,
                    StoreName = e.Store.StoreName,
                    GrossCommission = purchases
                        .Where(p => p.EmployeeId == e.Id)
                        .Sum(p => p.CommissionMade)
                });

            return SortStoreList(employeeList, direction, property);
        }

        public async Task<ExtendedEmployeeModel> GetExtendedEmployee(int id)
        {
            var date = DateTime.UtcNow.AddYears(-1);

            var e = await _employeeRepository.GetExtendedEmployee(id);
            // Grabbbing all the employee sales and grouping by the productId
            // so the count can be ordered. Then taking the first grouping as the most sold.
            var mostSoldProduct = e.Sales
                .GroupBy(s => s.ProductId)
                .OrderByDescending(s => s.Count())
                .ThenByDescending(s => s.Sum(p => p.CommissionMade))
                .FirstOrDefault();

            return new ExtendedEmployeeModel()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                StoreId = e.StoreId,
                HireDate = e.HireDate,
                EmploymentStatus = e.EmploymentStatus.StatusName,
                StoreName = e.Store.StoreName,
                GrossCommission = e.Sales
                    .Where(s => s.CreatedAt >= date)
                    .Sum(s => s.CommissionMade),
                LifetimeCommissionMade = e.Sales
                    .Sum(s => s.CommissionMade),
                Sales = e.Sales
                    .Select(s => new BasePurchaseModel()
                    {
                        Id = s.Id,
                        CreatedAt = s.CreatedAt,
                        ProductId = s.ProductId,
                        ProductName = s.Product.Name,
                        SalePrice = s.SalePrice,
                        CommissionMade = s.CommissionMade
                    })
                    .OrderByDescending(s => s.CreatedAt)
                    .ToList(),
                MostSoldProductId = mostSoldProduct.FirstOrDefault().ProductId,
                MostSoldProduct = mostSoldProduct.FirstOrDefault().Product.Name,
                MostSoldProductTotal = mostSoldProduct.Count()
            };
        }

        public List<BaseEmployeeModel> SortStoreList(IEnumerable<BaseEmployeeModel> employees, string direction, string property)
        {
            switch (property)
            {
                case "name":
                    return (direction == "asc" ? employees.OrderBy(s => s.FirstName).ThenBy(s => s.LastName) : employees.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName)).ToList();
                case "store":
                    return (direction == "asc" ? employees.OrderBy(s => s.StoreName) : employees.OrderByDescending(s => s.StoreName)).ToList();
                case "status":
                    return (direction == "asc" ? employees.OrderBy(s => s.EmploymentStatus) : employees.OrderByDescending(s => s.EmploymentStatus)).ToList();
                case "comission":
                    return (direction == "asc" ? employees.OrderBy(s => s.GrossCommission) : employees.OrderByDescending(s => s.GrossCommission)).ToList();
                default:
                    return (direction == "asc" ? employees.OrderBy(s => s.FirstName).ThenBy(s => s.LastName) : employees.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName)).ToList();
            }
        }

    }
}
