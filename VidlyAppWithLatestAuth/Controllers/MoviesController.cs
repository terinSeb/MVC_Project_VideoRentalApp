using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAppWithLatestAuth.ViewModals;
using VidlyAppWithLatestAuth.Models;
using VidlyAppWithLatestAuth.ViewModals;
using AutoMapper;
using VidlyAppWithLatestAuth.DTOs;

namespace VidlyAppWithLatestAuth.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public  ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyGetMovies");
        }
        // GET: Movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        public  IEnumerable<MoviesDTO> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include("Genre")
                .Where(m => m.NumberAvailable > 0);
            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));
            
            return moviesQuery.ToList().Select(Mapper.Map<Movie, MoviesDTO>);
        }
        [Route("movies/Details/{id:regex(\\d{1}):range(1,2)}")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include("MembershipType").SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult MovieDetails(int Id)
        {
            var MovieDetails = _context.Movies.Include("Genre").SingleOrDefault(c => c.Id == Id);
            if (MovieDetails == null)
                return HttpNotFound();
            return View(MovieDetails);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult EditMovies(int Id)
        {
            var movies = _context.Movies.Include("Genre").SingleOrDefault(c => c.Id == Id);
            var genres = _context.Genres.ToList();
            if (movies == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movies)
            {
                genres = genres
            };
            return View("MoviesForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {                
                genres = genres
            };
            return View("MoviesForm", viewModel);
        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();
                var viewModel = new MovieFormViewModel(movie)
                {                   
                    genres = genres
                };
                return View("MoviesForm", viewModel);
            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInRb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                MovieInRb.Name = movie.Name;
                MovieInRb.ReleaseDate = movie.ReleaseDate;
                MovieInRb.GenreId = movie.GenreId;
                MovieInRb.NumberInStock = movie.NumberInStock;                
            }
            _context.SaveChanges();
            return RedirectToAction("GetMovies", "Movies");
        }
    }
}