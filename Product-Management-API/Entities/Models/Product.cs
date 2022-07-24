using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
