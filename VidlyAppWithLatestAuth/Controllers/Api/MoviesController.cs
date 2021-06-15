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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovies(string query = null)
        {
            var MoviesQuery = _context.Movies.Include("Genre").Where(n => n.NumberAvailable > 0);
            if (!string.IsNullOrWhiteSpace(query))
            {
                MoviesQuery = MoviesQuery.Where(n => n.Name.Contains(query));                
            }
           
                var MovieList = MoviesQuery.ToList().Select(Mapper.Map<Movie, MoviesDTO>);
                return Ok(MovieList);
            
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.Include("Genre").SingleOrDefault(x => x.Id == Id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MoviesDTO>(movie));
        }
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MoviesDTO movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MoviesDTO, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int Id , MoviesDTO moviesDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if(MovieInDb == null)
            {
                NotFound();
            }
            Mapper.Map(moviesDTO, MovieInDb);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var MovieinDb = _context.Movies.SingleOrDefault(x => x.Id == Id);
            if (MovieinDb == null)
                return NotFound();
            _context.Movies.Remove(MovieinDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
