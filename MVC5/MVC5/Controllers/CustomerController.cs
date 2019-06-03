using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC5.Models;
using MVC5.ViewModels;

namespace MVC5.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipType = membershipType
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(a => a.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewLetter = customer.IsSubscribedToNewLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(a => a.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult ViewCustomer(int id)
        {
            var customer = _context.Customers.Include(a => a.MembershipType).First(a => a.Id == id);

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(a => a.Id == id);

            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}