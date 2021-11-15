using EmployeeSales.Models.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Repositories
{
    interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeListModel>> GetEmployeeList();
    }
}
