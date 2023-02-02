using DataBaseRepository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Common.ExtensionMethods
{
    public static class EnumExtensionMethods
    {
        public static string ToPersian(this InvoiceStatus status)
        {
            switch (status)
            {
                case InvoiceStatus.PreInvoice:
                    return "پیش فاکتور";

                case InvoiceStatus.Invoiced:
                    return "فاکتور شده";
                    
                case InvoiceStatus.Rejected:
                    return "مرجوعی";
                default:
                    return "";
            }
        }
    }
}
