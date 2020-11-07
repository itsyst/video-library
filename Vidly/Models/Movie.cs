using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id{ get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        public Genre Genre{ get; set; }

        
        [Display(Name = "Genre")]
        [Required]
        public int GenreId{ get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate{ get; set; }

        public DateTime DateAdded{ get; set; }

        
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

    }
}
