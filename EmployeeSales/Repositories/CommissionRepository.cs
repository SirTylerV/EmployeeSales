using EmployeeSales.Data;
using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Repositories
{
    public class CommissionRepository : ICommissionRepository
    {
        private readonly EmployeeSalesDbContext _db;
        public CommissionRepository(
            EmployeeSalesDbContext db
            )
        {
            _db = db;
        }

        public async Task<Commission> GetCommissionByProfitPrecent(decimal profitPrecent)
        {
            return await _db.Commission
                .Where(c => c.ProfitEligibility <= profitPrecent)
                .OrderByDescending(c => c.ProfitEligibility)
                .FirstOrDefaultAsync();
        }
    }
}
