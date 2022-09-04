using Identity_User.Models;
using Identity_User.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_User.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UsersController(UserManager<ApplicationUser> _UserManager, RoleManager<IdentityRole> roleManager)
        {
            userManager = _UserManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.Select(u => new UserModel {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                UserName = u.UserName,
                Roles= userManager.GetRolesAsync(u).Result
            }).ToListAsync();
            return View(users);
        }
    }
}
