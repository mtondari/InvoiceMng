using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataBaseRepository;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.ViewModels;

namespace StoreManagement.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(StoreDbContext storeDbContext)
            :base(storeDbContext)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
