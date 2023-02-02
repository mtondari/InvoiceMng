using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Invoices
{
    public class InvoiceListViewModel : BaseViewModel
    {
        public InvoiceListViewModel()
        {
            Invoices = new List<InvoiceListItemViewModel>();
        }

        public string SearchWord { get; set; }

        public List<InvoiceListItemViewModel> Invoices { get; set; }
    }
}
