using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.Employee;
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

        public List<EmployeeListModel> GetEmployees(string direction, string property)
        {
            var date = DateTime.UtcNow.AddYears(-1);

            var purchases = _purchaseRepository.GetPurchasesAfterDate(date);
            var employeeList = _employeeRepository.GetEmployees()
                .Select(e => new EmployeeListModel()
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

        public List<EmployeeListModel> SortStoreList(IEnumerable<EmployeeListModel> employees, string direction, string property)
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
