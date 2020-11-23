using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dentist.Models
{
    public class Product
    {

        public int ProductID { get; set; }
        [Display(Name ="Company Name" )]
        public string CompanyName { get; set; }
        [Display(Name = "Product Name")]
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}