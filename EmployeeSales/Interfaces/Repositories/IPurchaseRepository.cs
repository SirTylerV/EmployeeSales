using EmployeeSales.Models.DB;
using System;
using System.Collections.Generic;

namespace EmployeeSales.Interfaces.Repositories
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetPurchasesAfterDate(DateTime date);
        IEnumerable<Purchase> GetPurchasesBeforeDate(DateTime date);
        IEnumerable<Purchase> GetPurchasesBetweenDates(DateTime start, DateTime end);
    }
}
