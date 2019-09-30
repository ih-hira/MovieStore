using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
using MovieStore.View_Models;

namespace MovieStore.Controllers
{
	public class MoviesController : Controller
	{
		// GET: Movies/Random
		public ActionResult MovieStore()
		{
			return View();
		}
		public ActionResult Customers()
		{
			var customers = new List<Customer>
			{
				new Customer{Name="John Smith"},
				new Customer{Name="Stephen Rock"},
				new Customer{Name="Jemmy Leinstar"}
			};
			var viewModel = new RandomMovieViewModel
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
			var viewModel = new RandomMovieViewModel
			{
				Movie = movies
			};
			return View(viewModel);
		}
		[Route("movies/details/{id}/")]
		public ActionResult Details(int id)
		{
			Customer customer;
			if(id==1)
			{
				customer = new Customer { Name = "John Smith" };
			}
			else if(id==2)
			{
				customer = new Customer { Name = "Stephen Rock" };
			}
			else if(id==3)
			{
				customer = new Customer { Name = "Jemmy Leinstar" };
			}
			else
			{
				customer = null;
			}
			return View(customer);
		}










		//public ActionResult Random()
		//{
		//	var movie = new Movie(){Name = "Harry Poter"};
		//	var customers = new List<Customer>
		//	{
		//		new Customer{Name="Customer 1"},
		//		new Customer{Name="Customer 2"},
		//		new Customer{Name="Customer 3"}
		//	};

		//	var viewModel = new RandomMovieViewModel
		//	{
		//		Movie = movie,
		//		Customers = customers
		//	};
		//	return View(viewModel);
		//}

		//public ActionResult Edit(int id)
		//{
		//	return Content("id = " + id);
		//}

		//[Route("movies/released/{year}/{month}")]
		//public ActionResult ByReleaseDate(int year, int month)
		//{
		//	return Content(year +"/"+ month);
		//}

	}
}