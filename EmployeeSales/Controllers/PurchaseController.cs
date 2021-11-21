using EmployeeSales.Interfaces.Services;
using EmployeeSales.Models.DB;
using EmployeeSales.Models.Purchase;
using EmployeeSales.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeSales.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IProductService _productService;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(
            IEmployeeService employeeService,
            IProductService productService,
            IPurchaseService purchaseService
            )
        {
            _employeeService = employeeService;
            _productService = productService;
            _purchaseService = purchaseService;
        }

        [Route("AddSaleView/{employeeId}")]
        public async Task<IActionResult> AddSaleView(int employeeId)
        {
            var employee = await _employeeService.GetBaseEmployee(employeeId);
            var purchase = new Purchase()
            {
                EmployeeId = employeeId,
                Employee = new Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                }
            };
            ViewBag.Products = _productService.GetProducts();

            return View(purchase);
        }

        [Route("SaleList/{property ?}/{direction ?}/{pageNumber ?}")]
        public IActionResult SaleList(string property = "name", string direction = "asc", int pageNumber = 1)
        {
            // Setting the sorting stuff
            ViewBag.SortDirection = direction;
            ViewBag.SortProperty = property;
            ViewBag.PageNumber = pageNumber;
            var pageSize = 25;
            // Getting the total purchases
            var purchases = _purchaseService.GetPurchases(direction, property);
            // Calculating the Max number of pages
            ViewBag.MaxPages = Math.Round(((decimal)purchases.Count / (decimal)pageSize), MidpointRounding.AwayFromZero);
            // Setting the page start and stop for the pagination
            PaginationService.SetStartAndEndPagination((int)ViewBag.MaxPages, (int)ViewBag.PageNumber, out int start, out int end);
            ViewBag.PaginateStart = start;
            ViewBag.PaginateEnd = end;
            // Return the paginated results
            return View(PaginationService.PaginateList<BasePurchaseModel>(purchases, pageNumber, pageSize));
        }

        [Route("SaveSale")]
        [HttpPost]
        public async Task<IActionResult> SaveSale(Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Products = _productService.GetProducts();
                var employee = await _employeeService.GetBaseEmployee(purchase.EmployeeId);
                purchase.Employee = new Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                };
                return View("AddSaleView", purchase);
            }
            // Create the purchase
            await _purchaseService.CreatePurchase(purchase);
            // Get the employee model and send it back to the view
            // return View("../Employee/EmployeeView", await _employeeService.GetExtendedEmployee(purchase.EmployeeId));
            return RedirectToAction($"EmployeeView", "Employee", new { id = purchase.EmployeeId });
        }
    }
}

