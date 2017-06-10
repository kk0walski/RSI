using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSI.Models
{
    public class ProductProductPhoto
    {
        [Key]
        [Column(Order = 0)]
        public int ProductID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ProductPhotoID { get; set; }
        public bool Primary { get; set; }
        [Required]
        public System.DateTime ModifiedDate { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual ProductPhoto ProductPhoto { get; set; }
    }
}