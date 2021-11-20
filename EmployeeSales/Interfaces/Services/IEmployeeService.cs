using EmployeeSales.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface IEmployeeService
    {
        List<BaseEmployeeModel> GetEmployees(string direction, string property);
        Task<ExtendedEmployeeModel> GetExtendedEmployee(int id);
        List<BaseEmployeeModel> SortStoreList(IEnumerable<BaseEmployeeModel> employees, string direction, string property);
    }
}
