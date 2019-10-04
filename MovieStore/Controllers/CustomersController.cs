using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
using MovieStore.View_Models;

namespace MovieStore.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		// GET: Customers
		public ActionResult Index()
		{

			//var customers = new List<Customer>
			//{
			//	new Customer{Name="John Smith"},
			//	new Customer{Name="Stephen Rock"},
			//	new Customer{Name="Jemmy Leinstar"}
			//};
			var customers = db.Customers.ToList();
			var viewModel = new MovieViewModel
			{
				Customers = customers
			};
			return View(viewModel);
			
		}
		[Route("movies/details/{id}/")]
		public ActionResult Details(int id)
		{
			var cust = db.Customers.SingleOrDefault(c => c.Id == id);
			Customer customer = new Customer { Name = cust.Name };
			//if (id == 1)
			//{
			//	customer = new Customer { Name = db.Customers.SingleOrDefault(c => c.Id == id).ToString() };
			//}
			//else if (id == 2)
			//{
			//	customer = new Customer { Name = "Stephen Rock" };
			//}
			//else if (id == 3)
			//{
			//	customer = new Customer { Name = "Jemmy Leinstar" };
			//}
			//else
			//{
			//	customer = null;
			//}
			return View(customer);
		}
	}
}