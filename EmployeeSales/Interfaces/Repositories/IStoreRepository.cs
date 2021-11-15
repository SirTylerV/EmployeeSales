using EmployeeSales.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        IEnumerable<StoreListModel> GetStoreListData();
        Task<StoreViewModel> GetStoreView(int id);
    }
}
