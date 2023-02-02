using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseRepository.Models
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool SoldOut { get; set; }
        
        [NotMapped]
        public int? Price { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
