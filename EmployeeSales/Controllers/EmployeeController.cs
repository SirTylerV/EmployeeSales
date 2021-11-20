using EmployeeSales.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeSales.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(
            IEmployeeService employeeService

            )
        {
            _employeeService = employeeService;
        }

        [Route("EmployeeList/{property ?}/{direction ?}")]
        public IActionResult EmployeeList(string property = null, string direction = null)
        {
            ViewBag.SortDirection = direction ?? "asc";
            ViewBag.SortProperty = property ?? "name";
            return View(_employeeService.GetEmployees(ViewBag.SortDirection, ViewBag.SortProperty));
        }

        [Route("EmployeeView/{id}")]
        public async Task<IActionResult> EmployeeView(int id)
        {
            return View(await _employeeService.GetExtendedEmployee(id));
        }
    }
}
