using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAppWithLatestAuth.Models;
using VidlyAppWithLatestAuth.ViewModals;
using System.Data.Entity;
namespace VidlyAppWithLatestAuth.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers       
        public ActionResult GetCustomers()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            var ViewModel = new RandomViewModal
            {
                Customers = customer
            };
            return View();
        }
        public ActionResult New()
        {
            var MemeberShipTypes = _context.MembershipTypes.ToList();
            var viewModal = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = MemeberShipTypes
            };
            return View("CustomerForm", viewModal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {           
                if (!ModelState.IsValid)
            {
                var MemeberShipTypes = _context.MembershipTypes.ToList();
                var viewModal = new CustomerFormViewModel
                {
                    Customer =customer,
                    MembershipTypes = MemeberShipTypes
                };
                return View("CustomerForm", viewModal);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);                
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(s => s.Id == customer.Id);
                    
                    customerInDb.Name = customer.Name;
                    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    customerInDb.MembershipType = customer.MembershipType;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;                    
                
            }
            _context.SaveChanges();
            return RedirectToAction("GetCustomers", "Customers");
        }
        public ActionResult Edit (int Id)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.Id == Id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
    }
}