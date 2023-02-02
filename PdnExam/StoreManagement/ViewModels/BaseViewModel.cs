using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            ErrorMessages = new List<string>();
        }

        public List<string> ErrorMessages { get; set; }
    }
}
