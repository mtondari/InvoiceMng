using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Products
{
    public class AddProductViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? InitiatePrice { get; set; }
        public bool SoldOut { get; set; }
    }
}
