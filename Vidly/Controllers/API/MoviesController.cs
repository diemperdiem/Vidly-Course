﻿using AutoMapper;
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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
        }

        [HttpPost]
        public IHttpActionResult SaveMovie(MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movieParse = (Mapper.Map<MovieDto, Movie>(movie));

                _context.Movies.Add(movieParse);
                _context.SaveChanges();

                movie.Id = movieParse.Id;

                return Created(new Uri(Request.RequestUri + "/" + movie.Id),movie);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movieDTO.Id);

                Mapper.Map(movieDTO, movieInDb);

                _context.SaveChanges();

                return Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id) 
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }
            else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();

                return Ok();
            }
        }

    }
}
