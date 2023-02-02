using DataBaseRepository.Enums;
using DataBaseRepository.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Invoices
{
    public class AddInvoiceViewModel : BaseViewModel
    {
        public AddInvoiceViewModel()
        {
            InvoiceItems = new List<AddInvoiceItemViewModel>();
            StatusOptions =
                new List<SelectListItem>()
                {
                    new SelectListItem("پیش فاکتور",InvoiceStatus.PreInvoice.ToString()),
                    new SelectListItem("فاکتور شد",InvoiceStatus.Invoiced.ToString()),
                    new SelectListItem("مرجوعی",InvoiceStatus.Rejected.ToString()),
                };
        }

        public List<SelectListItem> StatusOptions { get; set; }

        public InvoiceStatus Status { get; set; }
        public int FinalPrice { get; set; }
        public string Description { get; set; }

        public List<AddInvoiceItemViewModel> InvoiceItems { get; set; }
        public List<Product> ActiveProductOptions { get; set; }
    }
}
