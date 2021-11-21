using EmployeeSales.Models.DB;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface IPurchaseService
    {
        Task CreatePurchase(Purchase purchase);
    }
}
