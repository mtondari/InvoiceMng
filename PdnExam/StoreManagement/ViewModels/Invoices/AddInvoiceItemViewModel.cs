using DataBaseRepository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Invoices
{
    public class AddInvoiceItemViewModel
    {
        public string ProductTitle { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int PriceItem { get; set; }
        public int FinalPrice { get; set; }
        public string FinalPriceStr => FinalPrice.ToPersianPriceString();
    }
}
