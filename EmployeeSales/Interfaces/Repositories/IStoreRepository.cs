using EmployeeSales.Models.Store;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeSales.Models.DB;

namespace EmployeeSales.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        IEnumerable<BaseStoreModel> GetStoreListData();
        Task<Store> GetStore(int id);
    }
}
