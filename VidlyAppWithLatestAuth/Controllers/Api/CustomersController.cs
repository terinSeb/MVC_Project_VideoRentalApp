using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAppWithLatestAuth.Models;
using VidlyAppWithLatestAuth.DTOs;
using AutoMapper;
using System.Data.Entity;
namespace VidlyAppWithLatestAuth.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomers(string query =null)
        {
            var customersQuery = _Context.Customers.Include(c => c.MembershipType);
            if(!string.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(n => n.Name.Contains(query));
            }
          var customersDtos = customersQuery
                 .ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customersDtos);
        }
        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _Context
                .Customers                
                .SingleOrDefault(a => a.Id == Id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }
        //POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);
            _Context.Customers.Add(customer);
            _Context.SaveChanges();
            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerdto);
        }
        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _Context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(customerDTO, customerInDb);
            //customerInDb.Name = customer.Name;
            //customerInDb.DateOfBirth = customer.DateOfBirth;
            //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _Context.SaveChanges();
            return Ok();
        }
        //Delete /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer( int Id)
        {
            var customer = _Context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer == null)
                return NotFound();
            _Context.Customers.Remove(customer);
            _Context.SaveChanges();
            return Ok();
        }
    }
}
