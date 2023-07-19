using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant.DepartmentsCode;
using Core.Constant;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    [Route("preshane")]
    public class preshaneController : Controller
    {
        private readonly ILogger<InsanKaynaklariController> _logger;
        private readonly IPersonelService _personelService;
        private readonly IShiftService _shiftService;
        private readonly IPersonelShiftService _personelShiftService;
        private readonly IPersonelOvertimeService _personelOvertimeService;

        public preshaneController(ILogger<InsanKaynaklariController> logger, IPersonelService personelService, IShiftService shiftService, IPersonelShiftService personelShiftService, IPersonelOvertimeService personelOvertimeService)
        {
            _logger = logger;
            _personelService = personelService;
            _shiftService = shiftService;
            _personelShiftService = personelShiftService;
            _personelOvertimeService = personelOvertimeService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {

            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, WeekOfDay.dayNow);
            if (result.Success)
            {
                var res = result.Data.Where(p => p.OvertimeDay == WeekOfDay.dayNow).ToList();
                return View(result.Data);
            }
            return View();
        }

        [HttpGet("vardiya")]
        public IActionResult shift()
        {
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, WeekOfDay.dayNow);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpGet("vardiya-ekle")]
        public IActionResult shift_add()
        {
            var res = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, WeekOfDay.dayNow);
            if (res.Success)
            {
                DepartmentsPersonelShiftsVM dpsvm = new DepartmentsPersonelShiftsVM();
                dpsvm.DepartmentsPersonelDtoVM = res.Data.Where(p => p.ShiftWeek != WeekOfDay.WeekNow).ToList();
                dpsvm.Shifts = _shiftService.GetAll().Data.ToList();
                return View(dpsvm);
            }
            return View();
        }

        [HttpPost("vardiya-ekle")]
        public IActionResult shift_add(DepartmentsPersonelShiftsVM p)
        {
            if (p.DepartmentsPersonelDtoVM == null)
            {
                return RedirectToAction("shift", "Preshane");
            }
            foreach (var item in p.DepartmentsPersonelDtoVM)
            {
                if (item.ShiftId != null)
                {
                    DepartmentsPersonelDto d = new DepartmentsPersonelDto();
                    d.ShiftId = item.ShiftId;
                    d.RegisterNo = item.RegisterNo;
                    d.ShiftWeek = WeekOfDay.WeekNow;
                    _personelShiftService.Add(d);
                }
            }
            return RedirectToAction("shift", "Preshane");
        }

        [HttpGet("vardiya-guncelle")]
        public IActionResult shift_update()
        {
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, WeekOfDay.dayNow);
            if (result.Success)
            {
                DepartmentsPersonelShiftsVM d = new DepartmentsPersonelShiftsVM();
                d.DepartmentsPersonelDtoVM = result.Data.ToList();
                d.Shifts = _shiftService.GetAll().Data.ToList();
                return View(d);
            }
            return View();
        }

        [HttpPost("vardiya-guncelle")]
        public IActionResult shift_update(DepartmentsPersonelShiftsVM p)
        {
            if (p == null)
            {
                return RedirectToAction("shift", "Preshane");
            }
            foreach (var item in p.DepartmentsPersonelDtoVM)
            {
                _personelShiftService.Update(item);
            }
            return RedirectToAction("shift", "Preshane");
        }


        [HttpGet("vardiya-sil")]
        public IActionResult shift_delete()
        {
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, WeekOfDay.dayNow);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpPost("vardiya-sil")]
        public IActionResult shift_delete(List<DepartmentsPersonelDto> personel)
        {
            if (personel == null)
            {
                return RedirectToAction("shift", "Preshane");
            }
            foreach (var item in personel)
            {
                if (item.check)
                {
                    _personelShiftService.Delete(item);
                }
            }
            //TODO: Implement Realistic Implementation
            return RedirectToAction("shift", "Preshane");
        }

        [HttpGet("sonraki-hafta-vardiya")]
        public IActionResult nextweek_shift()
        {
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNext, WeekOfDay.dayNow);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpGet("sonraki-hafta-vardiya-ekle")]
        public IActionResult nextweek_shift_add()
        {
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNext, WeekOfDay.dayNow);
            if (result.Success)
            {
                var thisWeek = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, WeekOfDay.dayNow).Data.ToList();
                var shifts = _shiftService.GetAll().Data.ToList();
                DepartmentsPersonelNextShiftsVM dps = new DepartmentsPersonelNextShiftsVM();
                dps.DepartmentsPersonelDtoNextShiftVM = result.Data.Where(p => p.ShiftWeek != WeekOfDay.WeekNext).ToList();
                dps.Shifts = shifts;
                dps.DepartmentsPersonelDtoVM = thisWeek;

                return View(dps);
            }
            return View();
        }

        [HttpPost("sonraki-hafta-vardiya-ekle")]
        public IActionResult nextweek_shift_add(DepartmentsPersonelNextShiftsVM p)
        {
            if (p.DepartmentsPersonelDtoNextShiftVM == null)
            {
                return RedirectToAction("nextweek_shift", "Preshane");
            }
            foreach (var item in p.DepartmentsPersonelDtoNextShiftVM)
            {
                if (item.ShiftId != null)
                {
                    DepartmentsPersonelDto d = new DepartmentsPersonelDto();
                    d.RegisterNo = item.RegisterNo;
                    d.ShiftWeek = WeekOfDay.WeekNext;
                    d.ShiftId = item.ShiftId;
                    _personelShiftService.Add(d);

                }
            }
            return RedirectToAction("nextweek_shift", "Preshane");
        }

        [HttpGet("sonraki-hafta-vardiya-guncelle")]
        public IActionResult nextweek_shift_update()
        {
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNext, WeekOfDay.dayNow);
            if (result.Success)
            {
                DepartmentsPersonelShiftsVM d = new DepartmentsPersonelShiftsVM();
                d.DepartmentsPersonelDtoVM = result.Data.ToList();
                d.Shifts = _shiftService.GetAll().Data.ToList();
                return View(d);
            }
            return View();
        }

        [HttpPost("sonraki-hafta-vardiya-guncelle")]
        public IActionResult nextweek_shift_update(DepartmentsPersonelShiftsVM p)
        {
            if (p == null)
            {
                return RedirectToAction("nextweek", "Preshane");
            }
            foreach (var item in p.DepartmentsPersonelDtoVM)
            {
                _personelShiftService.Update(item);
            }
            return RedirectToAction("nextweek_shift", "Preshane");
        }

        [HttpGet("sonraki-hafta-vardiya-sil")]
        public IActionResult nextweek_shift_delete()
        {
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNext, WeekOfDay.dayNow);
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
        }

        [HttpPost("sonraki-hafta-vardiya-sil")]
        public IActionResult nextweek_shift_delete(List<DepartmentsPersonelDto> personel)
        {
            if (personel == null)
            {
                return RedirectToAction("nextweek_shift", "Preshane");
            }
            foreach (var item in personel)
            {
                if (item.check)
                {
                    _personelShiftService.Delete(item);
                }
            }
            return RedirectToAction("nextweek_shift", "Preshane");
        }

        [HttpGet("mesai")]
        public IActionResult overtime(string date)
        {
            if (date == null)
            {
                date = WeekOfDay.dayNow;
            }
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, date);
            if (result.Success)
            {
                OvertimeVM o = new OvertimeVM();
                o.Date = date;
                o.DepartmentsPersonelDto = result.Data.Where(p => p.OvertimeDay == date).ToList();
                return View(o);
            }
            return View();
        }

        [HttpGet("mesai-ekle")]
        public IActionResult overtime_add(string overtimeadd_date_input)
        {
            if (overtimeadd_date_input == null)
            {
                overtimeadd_date_input = WeekOfDay.dayNow;
            }
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, overtimeadd_date_input);
            if (result.Success)
            {
                var res = result.Data.Where(p => p.OvertimeDay != overtimeadd_date_input).ToList();
                OvertimeVM o = new OvertimeVM();
                o.Date = overtimeadd_date_input;
                o.DepartmentsPersonelDto = res;
                return View(o);
            }
            return View();
        }

        [HttpPost("mesai-ekle")]
        public IActionResult overtime_add(OvertimeVM p, string overtimeadd_date)
        {
            if (p.DepartmentsPersonelDto == null)
            {
                return RedirectToAction("overtime", "Preshane");
            }
            foreach (var item in p.DepartmentsPersonelDto)
            {
                if (item.OvertimeId != null)
                {
                    Personelovertime po = new Personelovertime();
                    po.Overtimeday = overtimeadd_date;
                    po.Sicilno = item.RegisterNo;
                    po.Overtimeid = item.OvertimeId;
                    _personelOvertimeService.Add(po);

                }
            }
            return RedirectToAction("overtime", "Preshane");
        }

        [HttpGet("mesai-guncelle")]
        public IActionResult overtime_update(string overtimeupdate_date_input)
        {
            if (overtimeupdate_date_input == null)
            {
                overtimeupdate_date_input = WeekOfDay.dayNow;
            }
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, overtimeupdate_date_input);
            if (result.Success)
            {
                OvertimeVM o = new OvertimeVM();
                o.Date = overtimeupdate_date_input;
                o.DepartmentsPersonelDto = result.Data.Where(p => p.OvertimeDay == overtimeupdate_date_input).ToList();
                return View(o);
            }
            return View();
        }

        [HttpPost("mesai-guncelle")]
        public IActionResult overtime_update(OvertimeVM p, string overtimeupdate_date)
        {
            if (p.DepartmentsPersonelDto == null)
            {
                return RedirectToAction("overtime", "Preshane");
            }
            foreach (var item in p.DepartmentsPersonelDto)
            {
                Personelovertime po = new Personelovertime();
                po.Overtimeday = overtimeupdate_date;
                po.Overtimeid = item.OvertimeId;
                po.Sicilno = item.RegisterNo;
                _personelOvertimeService.Update(po);
            }
            return RedirectToAction("overtime", "Preshane");
        }

        [HttpGet("mesai-silme")]
        public IActionResult overtime_delete(string overtimedelete_date_input)
        {
            if (overtimedelete_date_input == null)
            {
                overtimedelete_date_input = WeekOfDay.dayNow;
            }
            var result = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane, WeekOfDay.WeekNow, overtimedelete_date_input);
            if (result.Success)
            {
                OvertimeVM o = new OvertimeVM();
                o.Date = overtimedelete_date_input;
                o.DepartmentsPersonelDto = result.Data.Where(p => p.OvertimeDay == overtimedelete_date_input).ToList();
                return View(o);
            }
            return View();
        }

        [HttpPost("mesai-silme")]
        public IActionResult overtime_delete(OvertimeVM p, string overtimedelete_date)
        {
            if (p.DepartmentsPersonelDto == null)
            {
                return RedirectToAction("overtime", "Preshane");
            }
            foreach (var item in p.DepartmentsPersonelDto)
            {
                if (item.check)
                {
                    Personelovertime po = new Personelovertime();
                    po.Sicilno = item.RegisterNo;
                    po.Overtimeday = overtimedelete_date;
                    _personelOvertimeService.Delete(po);
                }
            }
            return RedirectToAction("overtime", "Preshane");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}