using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSI.Models
{
    public class Category
    {
        [Key]
        public int ProductCategoryID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}