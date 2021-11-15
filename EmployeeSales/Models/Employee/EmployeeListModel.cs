﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Models.Employee
{
    public class EmployeeListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StoreId { get; set; }
        public byte EmploymentStatusId { get; set; }
        public decimal GrossCommission { get; set; }
    }
}
