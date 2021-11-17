using EmployeeSales.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface IEmployeeService
    {
        List<EmployeeListModel> GetEmployees(string direction, string property);
        // Task<EmployeeViewModel> GetEmployeeView(int employeeId);
        List<EmployeeListModel> SortStoreList(IEnumerable<EmployeeListModel> employees, string direction, string property);
    }
}
