using DropDownFilter.Models;
using DropDownFilter.Models.Comman;
using DropDownFilter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DropDownFilter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IManageService<DropDownModel, PaginationModel> _filterListingService;

        public HomeController(ILogger<HomeController> logger,
            IManageService<DropDownModel, PaginationModel> filterListingService)
        {
            _logger = logger;
            _filterListingService = filterListingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Filter(DropDownModel dropDownModel)
        {
            try
            {
                var response = await _filterListingService.PostAsync(UrlConstants.FilterListingUrl, dropDownModel);
                return PartialView("_UserFilterList", response);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
