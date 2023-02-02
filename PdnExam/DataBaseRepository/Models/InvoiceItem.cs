using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseRepository.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int FinalPrice { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductPriceId { get; set; }
        public ProductPrice ProductPrice { get; set; }
    }
}
