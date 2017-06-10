using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSI.Models
{
    public class ClientOffer
    {

        [Key]
        public int OfferID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh-mm}", ApplyFormatInEditMode = true)]
        public System.DateTime OfferDate { get; set; }
        [Required]
        public decimal offer { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual ApplicationUser Client { get; set; }
    }
}