using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
	public class Movie
	{
		public int Id { get; set; }
		[Required(ErrorMessage="Please enter movie name")]
		[StringLength(255)]
		public string Name { get; set; }
		public Genre Genre { get; set; }
		[Required]
		public byte GenreId { get; set; }

		[Display(Name= "Date Added")]
		public DateTime DateAdded { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "Number in Stock")]
        [MovieStockRange]
		public byte NumberInStock { get; set; }
	}
}