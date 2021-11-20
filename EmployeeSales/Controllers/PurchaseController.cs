using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Controllers
{
    public class PurchaseController : Controller
    {
        [Route("AddSale/{id}")]
        public IActionResult AddSale(int employeeId)
        {
            return View();
        }
    }
}
