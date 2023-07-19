using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant.DepartmentsCode;
using Core.Constant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("departmanlar")]
    public class DepartmentsController : Controller
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IPersonelService _personelService;

        public DepartmentsController(ILogger<DepartmentsController> logger,IPersonelService personelService)
        {
            _logger = logger;
            _personelService = personelService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.InsanKaynaklari = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.InsanKaynaklari,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.IdariIsler = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.IdariIsler,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.Ithalat = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Ithalat,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.Ihracat = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Ihracat,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.GrafikTasarim = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.GrafikTasarim,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.IsSagligiveGuvenligi = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.IsSagligiveGuvenligi,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.Muhasebe = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Muhasebe,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.satinalma = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.SatinAlma,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.satisvepazarlama = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.SatisvePazarlama,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.kaliphane = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Kaliphane,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.teknikservis = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.TeknikServis,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.arge = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.ArGe,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.uretim = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Uretim,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.kalitekontrol = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.KaliteKontrol,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.bilgiislem = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.BilgiIslem,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.disgorev = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.DisGorev,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.akulumontaj = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.AkuluMontaj,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.bakimonarim = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.BakimOnarim,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.enjeksiyon = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Enjeksiyon,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.malkabul = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.MalKabul,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.mobilya = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Mobilya,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.oyuncakmontaj = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.OyuncakMontaj,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.preshane = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Preshane,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.sevkiyatdepo = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.SevkiyatDepo,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.sisirme = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Sisirme,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.planlama = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Planlama,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.yarimamuldepo = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.YariMamulDepo,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.yemekhane = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Yemekhane,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.pilsanstore = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Pilsanstore,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();
            ViewBag.guvenlik = _personelService.GetAllDepartmentsPersonelDto(DepartmentsCode.Guvenlik,WeekOfDay.WeekNow,WeekOfDay.dayNow).Data.ToList().Count();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}