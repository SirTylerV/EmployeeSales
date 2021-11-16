using EmployeeSales.Interfaces.Services.Store;
using EmployeeSales.Models.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IStoreService _storeService;

        public StoreController(
            ILogger<StoreController> logger,
            IStoreService storeService
            )
        {
            _logger = logger;
            _storeService = storeService;
        }

        [Route("StoreList/{property ?}/{direction ?}")]
        public IActionResult StoreList(string property = null, string direction = null)
        {
            ViewBag.SortDirection = direction ?? "asc";
            ViewBag.SortProperty = property ?? "name";

            return View(_storeService.GetStores(ViewBag.SortDirection, ViewBag.SortProperty));
        }

        [Route("StoreView/{id}")]
        public async Task<IActionResult> StoreView(int id)
        {
            return View(await _storeService.GetStoreView(id));
        }
    }
}
