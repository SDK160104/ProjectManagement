using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangement.Domain
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }   
        public int ProductNoOfStock { get; set; }

    }
}
