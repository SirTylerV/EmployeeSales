using EmployeeSales.Data;
using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Models.Store;
using EmployeeSales.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Repositories.Store
{
    public class StoreRepository : IStoreRepository
    {
        private readonly EmployeeSalesDbContext _db;
        public StoreRepository(
            EmployeeSalesDbContext db
            )
        {
            _db = db;
        }

        public IEnumerable<StoreListModel> GetStoreListData()
        {
            return _db.StoreListModel.FromSqlRaw(StoredProcedures.GetProcedure(Enums.StoredProcedureEnum.GetStoreListData));
        }
    }
}
