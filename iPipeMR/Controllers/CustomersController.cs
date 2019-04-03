using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iPipeMR.Models;
using iPipeMR.ViewModel;
using System.Data.Entity;

namespace iPipeMR.Controllers
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
        public ViewResult Index()
        {
/*Note that .Include is used here to ensure that all related objects with customer are queried when this object is to be displayed in the view*/
            var customers = _context.Customers.Include(c => c.MembershipType);
/*
 It should be noted that we can immediately execute a query on this method by doing the below
            var customers = _context.Customers.toList();
*/

            return View(customers);
        }

        public ActionResult Details(int id)
        {
/*Note that our query is immediately executed here due to the single or default method attached to it*/
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}