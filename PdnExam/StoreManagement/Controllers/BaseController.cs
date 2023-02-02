using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataBaseRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.ViewModels;

namespace StoreManagement.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public StoreDbContext StoreDbContext { get; set; }

        //public BaseController()
        //{
        //}

        public BaseController(StoreDbContext storeDbContext)
        {
            this.StoreDbContext = storeDbContext;
        }
    }
}
