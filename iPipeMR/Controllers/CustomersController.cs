using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iPipeMR.Models;
using iPipeMR.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Runtime.Caching.Generic;

namespace iPipeMR.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customers = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel customer) 
        {
/*This below if-statement is adding validation to the form*/
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customers = customer.Customers,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            /*Checking if its a new customer*/
            if (customer.Customers.Id == 0)
            {
                _context.Customers.Add(customer.Customers);  /*Doing this is just being added to the memory*/
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Customers.Id);
                customerInDb.Name = customer.Customers.Name;
                customerInDb.Birthdate = customer.Customers.Birthdate;
                customerInDb.MembershipTypeId = customer.Customers.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.Customers.IsSubscribedToNewsLetter;

                //Mapper.map(customer, customerInDb); /*Another way to update the properties#1#


                /*TryUpdateModel(customerInDb);#1#
                /*You can use this approach to update the database based on given ID. We don't like this because of security where this allows us to blindly update all properties to the database*/

                
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ViewResult Index()
        {
/*Note that .Include is used here to ensure that all related objects with customer are queried when this object is to be displayed in the view*/
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
/*
 It should be noted that we can immediately execute a query on this method by doing the below
            var customers = _context.Customers.toList();
*/          
            
            return View();
        }

        public ActionResult Details(int id)
        {
/*Note that our query is immediately executed here due to the single or default method attached to it*/
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}