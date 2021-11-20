using System;
using System.Collections.Generic;

namespace EmployeeSales.Models.DB
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int StoreId { get; set; }
        public byte EmploymentStatusId { get; set; }

        public Store Store { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        // To an Employee, these are sales since they did not make a purchase
        public virtual ICollection<Purchase> Sales { get; set; }
    }
}
