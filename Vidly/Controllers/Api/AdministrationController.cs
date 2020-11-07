using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vidly.ViewModel;

namespace Vidly.Controllers.Api
{
    public class AdministrationController : Controller
    {
        public readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("RoleForm");
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.Name
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole).ConfigureAwait(true);

                if (result.Succeeded)
                {
                    RedirectToAction("index", "Home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
