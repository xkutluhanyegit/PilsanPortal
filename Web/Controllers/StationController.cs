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
    [Route("durak-dagilimi")]
    public class StationController : Controller
    {
        private readonly ILogger<StationController> _logger;
        private readonly IPersonelService _personelService;

        public StationController(ILogger<StationController> logger, IPersonelService personelService)
        {
            _logger = logger;
            _personelService = personelService;
        }

        [HttpGet("")]
        public IActionResult Index(int overtimeId, string serviceName)
        {
            var result = _personelService.GetAllHRPersonelDto(WeekOfDay.WeekNow, WeekOfDay.dayNow);

            if (result.Success)
            {
                List<HRPersonelDto> h = new List<HRPersonelDto>();
                var res = result.Data.Where(p => p.serviceName == serviceName);
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