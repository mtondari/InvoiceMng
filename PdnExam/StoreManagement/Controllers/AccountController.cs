using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.ViewModels.Account;

namespace StoreManagement.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager , StoreDbContext storeDbContext)
            : base(storeDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region UserList

        public async Task<IActionResult> Index(UserListViewModel viewModel)
        {
            var userNames = 
                await GetUserNamesByFilterAndGenerateUserListItemViewModels(viewModel);

            viewModel.UserList = userNames;

            return View(viewModel);
        }

        private async Task<List<UserListItemViewModel>> GetUserNamesByFilterAndGenerateUserListItemViewModels(UserListViewModel viewModel)
        {
            return
                await _userManager.Users
                    .Where(o =>
                        viewModel.SearchedWord == null ||
                        o.UserName.Contains(viewModel.SearchedWord)
                    )
                    .Select(o =>
                        new UserListItemViewModel
                        {
                            UserName = o.UserName
                        }
                    )
                    .ToListAsync();
        }

        #endregion

        #region Register

        [AllowAnonymous]
        public IActionResult Register()
        {
            var viewModel =
                new RegisterViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "ثبت کاربر با موفقیت انجام شد.";
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        #endregion

        #region Login

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (await _userManager.Users.CountAsync() == 0)
            {
                var user = new IdentityUser
                {
                    UserName = "m.tondari@gmail.com",
                    Email = "m.tondari@gmail.com"
                };
                await _userManager.CreateAsync(user, "!QAZxsw2");
            }

            var viewModel =
                new LoginViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Products");
                }

                ModelState.AddModelError(string.Empty, "تلاش برای ورود نامعتبر است");

            }

            return View(user);
        }

        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        #endregion
    }
}