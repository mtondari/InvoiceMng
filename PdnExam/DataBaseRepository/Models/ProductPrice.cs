using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseRepository.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
