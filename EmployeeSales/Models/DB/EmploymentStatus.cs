using System.Collections.Generic;

namespace EmployeeSales.Models.DB
{
    public class EmploymentStatus
    {
        public byte Id { get; set; }
        public string StatusName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
