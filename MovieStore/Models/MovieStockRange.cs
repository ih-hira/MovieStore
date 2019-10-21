using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class MovieStockRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            return movie.NumberInStock > 0 ? ValidationResult.Success :
                new ValidationResult("The field number of stock must be between 1 to 20");
        }
    }
}