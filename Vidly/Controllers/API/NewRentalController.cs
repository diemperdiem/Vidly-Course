using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //if (newRental.MovieIds.Count == 0)
            //{
            //    return BadRequest("No Movies where registered for rental");
            //}

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            //if (customer == null)
            //{
            //    return BadRequest("CustomerId is not valid");
            //}

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != newRental.MovieIds.Count)
            //{
            //    return BadRequest("One or more moviesIds are invalid");
            //}

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable <= 0)
                {
                    return BadRequest("Movie is not available");
                }
                else
                {
                    movie.NumberAvailable--;

                    var rental = new Rental()
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };

                    _context.Rentals.Add(rental);
                };

                _context.SaveChanges();

                
            }
            return Ok();

        }
    }
}
