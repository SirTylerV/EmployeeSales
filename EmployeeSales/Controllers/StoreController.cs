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
        private readonly IStoreService _storeListService;

        public StoreController(
            ILogger<StoreController> logger,
            IStoreService storeListService
            )
        {
            _logger = logger;
            _storeListService = storeListService;
        }

        [Route("StoreList/{property ?}/{direction ?}")]
        public IActionResult StoreList(string property = null, string direction = null)
        {
            ViewBag.SortDirection = direction ?? "asc";
            ViewBag.SortProperty = property ?? "name";

            return View(_storeListService.GetStores(ViewBag.SortDirection, ViewBag.SortProperty));
        }

        [Route("StoreView/{id}")]
        public IActionResult StoreView(string id)
        {
            return View();
        }
    }
}
