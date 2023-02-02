using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModels.Account
{
    public class UserListViewModel:BaseViewModel
    {
        public UserListViewModel()
        {
            UserList = new List<UserListItemViewModel>();
        }

        public string SearchedWord { get; set; }

        public List<UserListItemViewModel> UserList { get; set; }
    }
}
