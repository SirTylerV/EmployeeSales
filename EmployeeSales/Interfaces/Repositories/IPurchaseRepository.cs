using EmployeeSales.Models.DB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Repositories
{
    public interface IPurchaseRepository
    {
        Task CreatePurchase(Purchase p);
        IEnumerable<Purchase> GetPurchasesAfterDate(DateTime date);
        IEnumerable<Purchase> GetPurchasesBeforeDate(DateTime date);
        IEnumerable<Purchase> GetPurchasesBetweenDates(DateTime start, DateTime end);
    }
}
