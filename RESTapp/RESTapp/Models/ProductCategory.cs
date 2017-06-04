using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class ProductCategory
    {
        private DateTime _date = DateTime.Now;
        [Key]
        public int ProductCategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate
        {
            get { return _date; }
            set { _date = value; }
        }
        public virtual ICollection<ProductSubcategory> ProductSubcategory { get; set; }
    }
}