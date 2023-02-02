using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Common.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string str)
        {
            return
                string.IsNullOrEmpty(str) ||
                string.IsNullOrWhiteSpace(str);
        }
    }
}
