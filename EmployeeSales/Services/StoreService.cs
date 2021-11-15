using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Interfaces.Services.Store;
using EmployeeSales.Models.Store;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Services.Store
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(
            IStoreRepository storeRepository
            )
        {
            _storeRepository = storeRepository;
        }

        public List<StoreListModel> GetStores(string direction, string property)
        {
            return SortStoreList(_storeRepository.GetStoreListData(), direction, property);
        }

        public List<StoreListModel> SortStoreList(IEnumerable<StoreListModel> stores, string direction, string property)
        {
            switch (property)
            {
                case "name":
                    return (direction == "asc" ? stores.OrderBy(s => s.StoreName) : stores.OrderByDescending(s => s.StoreName)).ToList();
                case "state":
                    return (direction == "asc" ? stores.OrderBy(s => s.State) : stores.OrderByDescending(s => s.State)).ToList();
                case "grossPay":
                    return (direction == "asc" ? stores.OrderBy(s => s.GrossYearlyProfit) : stores.OrderByDescending(s => s.GrossYearlyProfit)).ToList();
                default:
                    return (direction == "asc" ? stores.OrderBy(s => s.StoreName) : stores.OrderByDescending(s => s.StoreName)).ToList();
            }
        }
    }
}
