using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Products
    {
        public int id { get; set; }

        [Required(ErrorMessage = "ProductName is requerd")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "ProductImage  is requerd")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "ProductDescription  is requerd")]
        public string ProductDescription { get; set; }
    }
}