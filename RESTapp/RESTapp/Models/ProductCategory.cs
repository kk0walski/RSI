using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<ProductSubcategory> ProductSubcategory { get; set; }
    }
}