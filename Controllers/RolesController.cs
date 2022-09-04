using Identity_User.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_User.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult>Add(RoleModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", await roleManager.Roles.ToListAsync());
            }
            if(await roleManager.RoleExistsAsync(roleModel.Name))
            {
                ModelState.AddModelError("Name", "Role is exists");
                return View("Index", await roleManager.Roles.ToListAsync());

            }
            await roleManager.CreateAsync(new IdentityRole(roleModel.Name.Trim()));
            return RedirectToAction("Index");

        }
    }
}
