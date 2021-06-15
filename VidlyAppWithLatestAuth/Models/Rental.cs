using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAppWithLatestAuth.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Movie Movies { get; set; }
        [Required]
        public Customer customer { get; set; }
        public DateTime  DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}