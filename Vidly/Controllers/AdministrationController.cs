using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdministrationController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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
                var identityRole = new IdentityRole
                {
                    Name = model.Name
                };

                var result = await _roleManager.CreateAsync(identityRole).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles", "Administration");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("RoleForm", model);
        }

        [HttpGet]
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles;

            return View("Index", roles);
        }


        // Role ID is passed from the URL to the action
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            // Find the role by Role ID
            var role = await _roleManager.FindByIdAsync(id).ConfigureAwait(true);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var modelView = new RoleFormViewModel
            {
                Id = role.Id,
                Name = role.Name
            };

            // Retrieve all users
            foreach (var user in _userManager.Users)
            {
                // If the user is in this role, add the username to
                // Users property of RoleViewModel. This model
                // object is then passed to the view for display
                if (await _userManager.IsInRoleAsync(user, role.Name).ConfigureAwait(true))
                {
                    modelView.Users.Add(user.UserName);
                }
            }

            return View(modelView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleFormViewModel modelView)
        {
            var role = await _roleManager.FindByIdAsync(modelView.Id).ConfigureAwait(true);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {modelView.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Id = modelView.Id;
                role.Name = modelView.Name;
                 

                // Update the Role using UpdateAsync
                var result = await _roleManager.UpdateAsync(role).ConfigureAwait(true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles",modelView);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("RoleForm", modelView);
            }


        }

    }
}
