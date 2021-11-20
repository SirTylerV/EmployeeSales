using System.Collections.Generic;

namespace EmployeeSales.Models.DB
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
