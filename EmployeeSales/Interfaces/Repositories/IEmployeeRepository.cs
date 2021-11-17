using EmployeeSales.Models.DB;
using EmployeeSales.Models.Employee;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployeesByStore(int storeId);
    }
}
