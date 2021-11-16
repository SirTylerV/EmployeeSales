using EmployeeSales.Data;
using EmployeeSales.Interfaces.Repositories;
using EmployeeSales.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSales.Repositories
{
    public class PurchaseRespository : IPurchaseRepository
    {
        private readonly EmployeeSalesDbContext _db;

        public PurchaseRespository(
            EmployeeSalesDbContext db
            )
        {
            _db = db;
        }

        public IEnumerable<Purchase> GetPurchasesAfterDate(DateTime date)
        {
            return _db.Purchase
                .Include(p => p.Product)
                .Where(p => p.CreatedAt >= date);
        }

        public IEnumerable<Purchase> GetPurchasesBeforeDate(DateTime date)
        {
            return _db.Purchase
                .Include(p => p.Product)
                .Where(p => p.CreatedAt <= date);
        }

        public IEnumerable<Purchase> GetPurchasesBetweenDates(DateTime start, DateTime end)
        {
            return _db.Purchase
                .Include(p => p.Product)
                .Where(p => p.CreatedAt >= start && p.CreatedAt <= end);
        }
    }
}
