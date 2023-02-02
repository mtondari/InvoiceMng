using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement
{
    public static class IntExtensionMethods
    {
        public static string ToPersianPriceString(this int? value)
        {
            if (value == null)
                return "---";

            return value.Value.ToPersianPriceString();
        }

        public static string ToPersianPriceString(this int value)
        {
            return $"{value.ToString("n0")} ریال";
        }
    }
}
