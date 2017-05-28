using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class ProductPhoto
    {
        [Key]
        public int ProductPhotoID { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public byte[] LargePhoto { get; set; }
        public string LargePhotoFileName { get; set; }
        [Required]
        public System.DateTime ModifiedDate { get; set; }
    }
}