using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStore.Models;

namespace MovieStore.View_Models
{
	public class RandomMovieViewModel
	{
		public List<Movie> Movie { get; set; }
		public List<Customer> Customers { get; set; }
	}
}