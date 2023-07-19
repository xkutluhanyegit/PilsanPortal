using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Constant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("menu")]
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IPersonelService _personelService;

        public MenuController(ILogger<MenuController> logger,IPersonelService personelService)
        {
            _logger = logger;
            _personelService = personelService;
        }

        public IActionResult Index()
        {
            var model = _personelService.GetAllHRPersonelDto(WeekOfDay.WeekNow,WeekOfDay.dayNow);
            return View("~/Views/Shared/_Header.cshtml", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}