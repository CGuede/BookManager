using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManager.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set;}

        [Required]
        public int AuthorID { get; set; }

        [Display(Name = "Author")]
        public virtual Author Author{ get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string ShortDesc { get; set; }

    }
}