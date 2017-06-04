using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class ProductSubcategory
    {
        [Key]
        public int ProductSubcategoryID { get; set; }
        [Required]
        public int ProductCategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        [Required]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}