using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
using MovieStore.View_Models;

namespace MovieStore.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext db;

		public MoviesController()
		{
			db = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
		}

		public ActionResult Index()
		{
			return View();
		}
		public ActionResult ListOfMovies()
		{
			var movies = db.Movies.Include(m => m.Genre).ToList();
			var viewModel = new ListViewModel
			{
				Movie = movies
			};
			return View(viewModel);
		}

		public ActionResult Details(int id)
		{
			var movie = db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
			Movie movieDetails = movie;
			return View(movieDetails);
		}

		public ActionResult Edit(int id)
		{
			var movie = db.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
			{
				return HttpNotFound();
			}

			var viewModel = new MovieFormViewModel
			{
				Movie = movie,
				Genres = db.Genres.ToList(),
				Title = "Edit Movie"
			};
			return View("MovieForm", viewModel);
		}

		public ActionResult NewMovie()
		{
			var genres = db.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{
				Genres = genres,
				Title = "New Movie"
			};
			return View("MovieForm",viewModel);
		}

		public ActionResult Save(Movie movie)
		{
			if (movie.Id == 0)
				db.Movies.Add(movie);
			else
			{
				var movieInDb = db.Movies.Single(m => m.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.Genre = movie.Genre;
				movieInDb.DateAdded = movie.DateAdded;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.NumberInStock = movie.NumberInStock;
			}
			try
			{
				db.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				Console.WriteLine(e);
			};
			return RedirectToAction("ListOfMovies", "Movies");
		}
		
	}
}
