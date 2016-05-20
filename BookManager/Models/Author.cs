using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManager.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}