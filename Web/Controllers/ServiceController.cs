using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Constant;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("mesai-saat-detay")]
    public class ServiceController : Controller
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IPersonelService _personelService;

        public ServiceController(ILogger<ServiceController> logger, IPersonelService personelService)
        {
            _logger = logger;
            _personelService = personelService;
        }

        [HttpGet("")]
        public IActionResult Index(int overtimeId)
        {
            
            var result = _personelService.GetAllHRPersonelDto(WeekOfDay.WeekNow, WeekOfDay.dayNow);
            if (result.Success)
            {
                List<HRPersonelDto> h = new List<HRPersonelDto>();
                var res = result.Data;
                foreach (var item in res)
                {
                    if (item.OvertimeId != null && item.OvertimeId == overtimeId)
                    {
                        h.Add(item);
                    }
                    else if (item.OvertimeId == null)
                    {
                        if (item.shiftId != null && item.shiftId == overtimeId)
                        {
                            h.Add(item);
                        }
                    }
                }
                ViewBag.OvertimeID = overtimeId;

                return View(h);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}