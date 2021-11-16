using EmployeeSales.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services.Store
{
    public interface IStoreService
    {
        List<StoreListModel> GetStores(string direction, string property);
        Task<StoreViewModel> GetStoreView(int storeId);
        List<StoreListModel> SortStoreList(IEnumerable<StoreListModel> stores, string direction, string property);
    }
}
