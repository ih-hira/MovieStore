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
		private ApplicationDbContext db = new ApplicationDbContext();

		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Customers()
		{
			//var customers = new List<Customer>
			//{
			//	new Customer{Name="John Smith"},
			//	new Customer{Name="Stephen Rock"},
			//	new Customer{Name="Jemmy Leinstar"}
			//};
			var customers = db.Customers.ToList();
			//var listOfCustomer = new List<Customer>();
			//foreach(var c in customers)
			//{
			//	listOfCustomer.Add(c);
			//}
			var viewModel = new MovieViewModel
			{
				Customers = customers
			};
			return View(viewModel);
		}
		public ActionResult ListOfMovies()
		{
			var movies = new List<Movie>
			{
				new Movie{Name="Harry Poter"},
				new Movie{Name="Jab We Met"},
				new Movie{Name="Shaap Ludu"}
			};
			var viewModel = new MovieViewModel
			{
				Movie = movies
			};
			return View(viewModel);
		}
		
	}
}
