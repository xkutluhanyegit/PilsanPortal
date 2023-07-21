using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers

{
    [Authorize(Roles = "Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(ILogger<AdminController> logger,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            SignUpVM s = new SignUpVM();
            var rolList = _roleManager.Roles.ToList();
            s.roles = rolList;

            return View(s);
        }

        [HttpPost("")]
        public async Task<IActionResult> Index(SignUpVM vm)
        {
          var signupResult = await _userManager.CreateAsync(
            new(){
                UserName = vm.username,
                Email = vm.email
            },vm.password
          );
          if (signupResult.Succeeded)
          {
            
            var currentUser = await _userManager.FindByEmailAsync(vm.email);
            var roleResult = await _userManager.AddToRoleAsync(currentUser,vm.roleName);
          }
          return View("admin","index");
        }

        [HttpGet("rol-ekle")]
        public IActionResult roleCreate()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        [HttpPost("rol-ekle")]
        public async Task<IActionResult> roleCreate(RolesVM vm)
        {
          var result = await _roleManager.CreateAsync( new AppRole(){
            Name = vm.RolName
          });
          if (result.Succeeded)
          {
            return RedirectToAction("index","admin");
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