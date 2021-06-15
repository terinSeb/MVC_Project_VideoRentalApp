using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAppWithLatestAuth.DTOs;
using VidlyAppWithLatestAuth.Models;

namespace VidlyAppWithLatestAuth.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(
                x => x.Id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return BadRequest("Movie is Not Available");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    customer = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };
                _context.Movies.Add(movie);
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}