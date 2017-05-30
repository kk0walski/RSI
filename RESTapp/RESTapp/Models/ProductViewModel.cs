using RESTapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class ProductViewModel
    {
        [Key]
        public ApplicationUser User { get; set; }
        public List<Product> UserProducts { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductSubcategory> ProductSubcategories { get; set; }
    }
}