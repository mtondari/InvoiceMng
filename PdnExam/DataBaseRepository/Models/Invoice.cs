using DataBaseRepository.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseRepository.Models
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }

        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public InvoiceStatus Status { get; set; }
        public int FinalPrice { get; set; }
        public string Description { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
