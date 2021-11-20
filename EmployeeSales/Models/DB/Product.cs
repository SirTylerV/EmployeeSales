using System.Collections.Generic;

namespace EmployeeSales.Models.DB
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Wholesale { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
