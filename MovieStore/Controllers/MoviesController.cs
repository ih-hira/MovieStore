using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
			//var movies = new List<Movie>
			//{
			//	new Movie{Name="Harry Poter"},
			//	new Movie{Name="Jab We Met"},
			//	new Movie{Name="Shaap Ludu"}
			//};
			var viewModel = new MovieViewModel
			{
				Movie = movies
			};
			return View(viewModel);
		}

		public ActionResult Details(int? id)
		{
			var movie = db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
			Movie movieDetails = movie;
			return View(movieDetails);
		}
		
	}
}
