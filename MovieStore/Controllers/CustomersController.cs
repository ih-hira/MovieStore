using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
using MovieStore.View_Models;

namespace MovieStore.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext db ;

		public CustomersController()
		{
			db = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
		}
		// GET: Customers
		public ActionResult Index()
		{
			var customers = db.Customers.Include(c => c.MembershipType).ToList();
			var viewModel = new ListViewModel
			{
				Customers = customers
			};
			return View(viewModel);
			
		}
		public ActionResult NewCustomer()
		{
			var membershipTypes = db.MembershipTypes.ToList();
			var viewModel = new CustomerFormViewModel
			{
				MembershipTypes = membershipTypes,
				Title = "New Customer"
			};
			return View("CustomerForm",viewModel);
		}

		[HttpPost]
		public ActionResult Save(Customer customer)
		{
			if (customer.Id == 0)
				db.Customers.Add(customer);
			else
			{
				var customerInDb = db.Customers.Single(c => c.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.BirthDate = customer.BirthDate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
			db.SaveChanges();
			return RedirectToAction("Index", "Customers");
		}
		public ActionResult Details(int id)
		{
			var cust = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
			Customer customer = cust;
			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = db.Customers.SingleOrDefault(c => c.Id == id);

			if(customer == null)
			{
				return HttpNotFound();
			}

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = db.MembershipTypes.ToList(),
				Title = "Edit Customer"
			};

			return View("CustomerForm",viewModel);
		}
	}
}