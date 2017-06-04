using RESTapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class Product
    {
        private DateTime _startDate = DateTime.Now;
        private DateTime _finishDate = DateTime.Now;
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Nie wpisales nazwy")]
        [MaxLength(40, ErrorMessage = "Za dluga nazwa")]
        [MinLength(2, ErrorMessage = "Za krotka nazwa")]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal InitialPrice { get; set; }
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm}", ApplyFormatInEditMode = true)]
        public System.DateTime SellStartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm}", ApplyFormatInEditMode = true)]
        public System.DateTime SellEndDate
        {
            get { return _finishDate; }
            set { _finishDate = value; }
        }
        public Nullable<int> ProductSubcategoryID { get; set; }
        public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }
        public virtual ProductSubcategory Subcategory { get; set; }
        [Required]
        public virtual ApplicationUser Wlasciciel { get; set; }
    }
}