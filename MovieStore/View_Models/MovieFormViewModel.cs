using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStore.Models;

namespace MovieStore.View_Models
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }

		public Movie Movie { get; set; }

		public string Title { get; set; }
	}
}