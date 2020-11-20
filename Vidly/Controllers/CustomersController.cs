using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("List");
            return View("ReadOnlyList");
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(m =>m.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound(404);

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var modelView = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", modelView);
            }
            if (customer.Id == 0)
                _context.Customers.AddAsync(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // This microsoft approach can open a security hols in our application
                //  TryUpdateModelAsync(customerInDb);
                //  TryUpdateModelAsync(customerInDb, "", new string["MembershipType"] {});
                // We want just to change some properties and manually set the customer propperties
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                // possible auto-mapper Install from nuget


            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}