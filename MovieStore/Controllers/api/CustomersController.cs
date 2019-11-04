using AutoMapper;
using MovieStore.DTO;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieStore.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db;

        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(db.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>));
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /ap/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            db.SaveChanges();
            return Ok();
        }

        //DELETE /api/cutomer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(customerInDb);
            db.SaveChanges();
            return Ok();
        }
    }
}
