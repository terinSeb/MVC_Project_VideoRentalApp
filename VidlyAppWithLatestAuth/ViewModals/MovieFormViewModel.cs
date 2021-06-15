using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAppWithLatestAuth.Models;
using System.ComponentModel.DataAnnotations;
namespace VidlyAppWithLatestAuth.ViewModals
{
    public class MovieFormViewModel
    {        
        public IEnumerable<Genre> genres { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }        
        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }        
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Number in Stock")]
        [Range(1, 10)]
        [Required]
        public byte? NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
        public string Title{get{return Id != 0 ? "Edit Movie" : "New Movie";}}
        public MovieFormViewModel(){Id = 0;}
        public MovieFormViewModel(Movie Movie)
        {Id = Movie.Id;Name = Movie.Name;
            GenreId = Movie.GenreId;
            ReleaseDate = Movie.ReleaseDate;
            NumberInStock = Movie.NumberInStock;
        }
    }
}