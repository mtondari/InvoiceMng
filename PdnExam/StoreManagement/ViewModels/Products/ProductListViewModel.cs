using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Products
{
    public class ProductListViewModel : BaseViewModel
    {
        public ProductListViewModel()
        {
            Products = new List<ProductListItemViewModel>();
            SoldOutOptions =
                new List<SelectListItem>()
                {
                    new SelectListItem("موجود در انبار",false.ToString()),
                    new SelectListItem("ناموجود در انبار",true.ToString())
                };
        }

        public List<SelectListItem> SoldOutOptions { get; set; }
        public bool? SoldOut { get; set; }
        public string SearchWord { get; set; }

        public List<ProductListItemViewModel> Products { get; set; }
    }
}
