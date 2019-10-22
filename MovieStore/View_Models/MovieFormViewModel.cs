using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStore.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.View_Models
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        [StringLength(255)]
        public string Name { get; set; }
       
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [MovieStockRange]
        [Required]
        public byte? NumberInStock { get; set; }

		public string Title { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
	}
}