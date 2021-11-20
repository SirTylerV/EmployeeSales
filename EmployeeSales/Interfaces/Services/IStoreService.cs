using EmployeeSales.Models.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface IStoreService
    {
        List<BaseStoreModel> GetStores(string direction, string property);
        Task<ExtendedStoreModel> GetStoreView(int storeId);
        List<BaseStoreModel> SortStoreList(IEnumerable<BaseStoreModel> stores, string direction, string property);
    }
}
