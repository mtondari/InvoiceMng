using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Products
{
    public class ProductListItemViewModel
    {
        public ProductListItemViewModel()
        {
        }

        public int ProductId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public string PriceStr => Price.ToPersianPriceString();
        public bool SoldOut { get; set; }
        public string SoldOutStr => SoldOut ? "ناموجود" : "موجود";

        public DateTime CreateDateTime { get; set; }
        public string CreateDateTimeStr => CreateDateTime.ToPersianDateTimeString();

        public DateTime LastUpdateDateTime { get; set; }
        public string LastUpdateDateTimeStr => LastUpdateDateTime.ToPersianDateTimeString();
    }
}
