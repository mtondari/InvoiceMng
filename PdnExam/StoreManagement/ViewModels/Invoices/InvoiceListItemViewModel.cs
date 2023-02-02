using DataBaseRepository.Enums;
using StoreManagement.Common.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Invoices
{
    public class InvoiceListItemViewModel
    {
        public int InvoiceId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string CreateDateTimeStr => CreateDateTime.ToPersianDateTimeString();
        public string Description { get; set; }
        public int FinalPrice { get; set; }
        public string FinalPriceStr => FinalPrice.ToPersianPriceString();
        public InvoiceStatus Status { get; set; }
        public string StatusStr => Status.ToPersian();
    }
}
