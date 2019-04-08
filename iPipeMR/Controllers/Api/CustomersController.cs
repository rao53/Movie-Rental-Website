using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using iPipeMR.Dtos;
using iPipeMR.Models;
using System.Data.Entity;
using iPipeMR.ViewModel;

namespace iPipeMR.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customerDtos);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        /*//POST /api/customer
        [HttpPost]https://www.youtube.com/watch?v=qronqk4xAkg
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, CustomerFormViewModel>(customerDto);
            _context.Customers.Add(customer.Customers);
            _context.SaveChanges();

            customerDto.Id = customer.Customers.Id;

            return customerDto;
        } */
        
        //POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
/*
                throw new HttpResponseException(HttpStatusCode.BadRequest);
*/
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customerInDb);
            /*customerInDb.Name = customerDto.Name;
            customerInDb.Birthdate = customerDto.Birthdate;
            customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;*/
/*The above lines aren't needed anymore since we have done the requirements with respect to mapping the CustomerDto and the customer*/

            _context.SaveChanges();
            return Ok();
        } 

        //Delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
