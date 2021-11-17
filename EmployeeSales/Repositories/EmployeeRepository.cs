using EmployeeSales.Data;
using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeSalesDbContext _db;
        public EmployeeRepository(
            EmployeeSalesDbContext db
            )
        {
            _db = db;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _db.Employee
                .Include(e => e.EmploymentStatus)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.Employee
                .Include(e => e.EmploymentStatus)
                .Include(e => e.Store);
        }

        public IEnumerable<Employee> GetEmployeesByStore(int storeId)
        {
            return _db.Employee
                .Include(e => e.EmploymentStatus)
                .Where(e => e.StoreId == storeId);
        }
    }
}
