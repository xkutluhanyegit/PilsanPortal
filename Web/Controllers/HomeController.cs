using System.Diagnostics;
using Business.Abstract;
using Core.Constant;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;


[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPersonelService _personelService;
    private readonly UserManager<AppUser> _userManager;
    

    public HomeController(ILogger<HomeController> logger,IPersonelService personelService,UserManager<AppUser> userManager)
    {
        _logger = logger;
        _personelService = personelService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        //Create No Form
        var signupResult = await _userManager.CreateAsync(
            new()
            {
                UserName = "kutluhanyegit@pilsan.com.tr",
                Email = "kutluhanyegit@pilsan.com.tr",
            },"helloWorld1991."
        );
        

        var result = _personelService.GetAllHRPersonelDto(WeekOfDay.WeekNow,WeekOfDay.dayNow);
        if (result.Success)
        {
            ViewBag.count = result.Data.Count();
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
