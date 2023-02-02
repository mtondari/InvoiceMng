using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataBaseRepository;
using DataBaseRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Common.ExtensionMethods;
using StoreManagement.ViewModels;
using StoreManagement.ViewModels.Products;

namespace StoreManagement.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(StoreDbContext storeDbContext)
            : base(storeDbContext)
        {

        }

        #region Index
        public async Task<IActionResult> Index(ProductListViewModel model)
        {
            var products =
                await GetProductsFromDb(model);

            ConvertProductsToViewModel(products, model);

            return View(model);
        }

        private async Task<List<Product>> GetProductsFromDb(ProductListViewModel model)
        {
            var products =
                await StoreDbContext.Products
                    .Include(o => o.ProductPrices)
                    .Where(o =>
                        (
                            model.SoldOut == null ||
                            o.SoldOut == model.SoldOut
                        ) &&
                        (
                            model.SearchWord == null ||
                            o.Title.Contains(model.SearchWord) ||
                            o.Description.Contains(model.SearchWord)
                        )
                    )
                    .Select(o =>
                        new Product
                        {
                            CreateDateTime = o.CreateDateTime,
                            LastUpdateDateTime = o.LastUpdateDateTime,
                            Description = o.Description,
                            Id = o.Id,
                            SoldOut = o.SoldOut,
                            Title = o.Title,
                            Price =
                                o.ProductPrices
                                    .FirstOrDefault(p =>
                                        p.EndDateTime == null
                                    )
                                    .Price
                        }
                    )
                    .ToListAsync();

            return products;
        }

        private ProductListViewModel ConvertProductsToViewModel(List<Product> products, ProductListViewModel viewModel)
        {
            viewModel.Products =
                products
                    .Select(o =>
                        GenerateProductListItemViewModelFromProduct(o)
                    )
                    .ToList();



            return viewModel;
        }

        private static ProductListItemViewModel GenerateProductListItemViewModelFromProduct(Product o)
        {
            return
                new ProductListItemViewModel
                {
                    CreateDateTime = o.CreateDateTime,
                    LastUpdateDateTime = o.LastUpdateDateTime,
                    Description = o.Description,
                    ProductId = o.Id,
                    SoldOut = o.SoldOut,
                    Title = o.Title,
                    Price = o.Price
                };
        }
        #endregion

        #region AddProduct

        public IActionResult Add()
        {
            return View(new AddProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            await ValidateAddProductAsync(viewModel);

            if (viewModel.ErrorMessages?.Count > 0)
            {
                return View(viewModel);
            }

            var product =
                GenerateProductAndProductPriceFromAddProductViewModel(viewModel);

            if (!(await InsertProductToDb(product)))
            {
                viewModel.ErrorMessages
                    .Add("عملیات درج محصول با خطا مواجه شد، لطفا مجدد تلاش نمایید.");

                return View(viewModel);
            }

            TempData["SuccessMessage"] = "درج محصول با موفقیت انجام شد.";

            return RedirectToAction("Index");
        }

        private async Task ValidateAddProductAsync(AddProductViewModel viewModel)
        {
            viewModel.Title = NormalizeTitle(viewModel.Title);

            viewModel.ErrorMessages.AddRange(
                await ValidateTitle(viewModel.Title)
            );

            viewModel.ErrorMessages
                .Add(
                    ValidatePrice(viewModel.InitiatePrice)
                );

            viewModel.ErrorMessages =
                viewModel.ErrorMessages
                    .Where(o => !o.IsNullOrEmptyOrWhiteSpace())
                    .ToList();
        }

        private string NormalizeTitle(string title)
        {
            return title?.Trim();
        }

        private async Task<List<string>> ValidateTitle(string title, int? productId = null)
        {
            var errorMessages = new List<string>();

            if (title.IsNullOrEmptyOrWhiteSpace())
                errorMessages.Add("درج عنوان الزامی است.");

            errorMessages =
                await CheckForDuplicateProductTitle(title, productId, errorMessages);

            return errorMessages;
        }

        private async Task<List<string>> CheckForDuplicateProductTitle(string title, int? productId, List<string> errorMessages)
        {
            var duplicateTitle =
                await StoreDbContext.Products
                    .AnyAsync(o =>
                        (
                            productId == null ||
                            o.Id != productId
                        ) &&
                        o.Title == title
                    );

            if (duplicateTitle)
                errorMessages.Add("عنوان محصول تکراری است.");

            return errorMessages;
        }

        private static string ValidatePrice(int? price)
        {
            if (price < 0)
                return "مقدار قیمت نامعتبر است.";

            return null;
        }

        public Product GenerateProductAndProductPriceFromAddProductViewModel(AddProductViewModel viewModel)
        {
            Product product = GenerateProductFromAddProductViewModel(viewModel);

            AddProductPriceToProduct(viewModel, product);

            return product;
        }

        private static Product GenerateProductFromAddProductViewModel(AddProductViewModel viewModel)
        {
            return new Product
            {
                CreateDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now,
                Description = viewModel.Description,
                Title = viewModel.Title,
                SoldOut = viewModel.SoldOut
            };
        }

        private static void AddProductPriceToProduct(AddProductViewModel viewModel, Product product)
        {
            if (viewModel.InitiatePrice == null)
                return;

            product.ProductPrices =
                new List<ProductPrice>
                {
                    new ProductPrice
                    {
                        Price = viewModel.InitiatePrice.Value,
                        StartDateTime = DateTime.Now
                    }
                };
        }

        public async Task<bool> InsertProductToDb(Product product)
        {
            try
            {
                await StoreDbContext.Products
                    .AddAsync(product);

                await StoreDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region EditProduct

        public async Task<IActionResult> Edit(int id)
        {
            var product =
                await StoreDbContext.Products
                    .Include(o => o.ProductPrices)
                    .FirstOrDefaultAsync(o => o.Id == id);

            if (product == null)
            {
                TempData["ErrorMessage"] = "محصولی با این شناسه یافت نشد.";
                return RedirectToAction("Index");
            }

            var viewModel =
                GenerateEditProductViewModelFromProduct(product);

            return View(viewModel);
        }

        private EditProductViewModel GenerateEditProductViewModelFromProduct(Product product)
        {
            var viewModel = InitiateViewModelByProduct(product);

            SetLastActivePrice(product, viewModel);

            return viewModel;
        }

        private static EditProductViewModel InitiateViewModelByProduct(Product product)
        {
            return
                new EditProductViewModel
                {
                    Description = product.Description,
                    ProductId = product.Id,
                    SoldOut = product.SoldOut,
                    Title = product.Title
                };
        }

        private static void SetLastActivePrice(Product product, EditProductViewModel viewModel)
        {
            var lastActiveProductPrice =
                product.ProductPrices?
                    .OrderByDescending(o => o.StartDateTime)
                    .FirstOrDefault();

            viewModel.Price = lastActiveProductPrice.Price;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel viewModel)
        {
            await ValidateEditProductAsync(viewModel);

            if (viewModel.ErrorMessages?.Count > 0)
            {
                return View(viewModel);
            }

            var product =
                await UpdateProductAndAddProductPriceIfNeededFromEditProductViewModel(viewModel);

            if (!(await UpdateProductToDb(product)))
            {
                viewModel.ErrorMessages
                    .Add("عملیات بروزرسانی محصول با خطا مواجه شد، لطفا مجدد تلاش نمایید.");

                return View(viewModel);
            }

            TempData["SuccessMessage"] = "بروزرسانی محصول با موفقیت انجام شد.";

            return RedirectToAction("Index");
        }

        private async Task ValidateEditProductAsync(EditProductViewModel viewModel)
        {
            viewModel.Title = NormalizeTitle(viewModel.Title);

            viewModel.ErrorMessages.Add(
                await ValidateProductId(viewModel.ProductId)
            );

            viewModel.ErrorMessages.AddRange(
                await ValidateTitle(viewModel.Title, viewModel.ProductId)
            );

            viewModel.ErrorMessages
                .Add(
                    ValidatePrice(viewModel.Price)
                );

            viewModel.ErrorMessages =
                viewModel.ErrorMessages
                    .Where(o => !o.IsNullOrEmptyOrWhiteSpace())
                    .ToList();
        }

        public async Task<string> ValidateProductId(int productId)
        {
            if (!(await StoreDbContext.Products.AnyAsync(o => o.Id == productId)))
                return "محصولی با چنین شناسه ای یافت نشد.";

            return string.Empty;

        }

        public async Task<Product> UpdateProductAndAddProductPriceIfNeededFromEditProductViewModel(EditProductViewModel viewModel)
        {
            var product = await FetchProductWithProductPricesFromDbById(viewModel.ProductId);

            product = UpdateProductFromEditProductViewModel(viewModel, product);

            AddProductPriceToProduct(viewModel, product);

            return product;
        }

        private async Task<Product> FetchProductWithProductPricesFromDbById(int productId)
        {
            return
                await StoreDbContext.Products
                    .Include(o => o.ProductPrices)
                    .FirstAsync(o => o.Id == productId);
        }

        private static Product UpdateProductFromEditProductViewModel(EditProductViewModel viewModel, Product product)
        {
            product.Description = viewModel.Description;
            product.Title = viewModel.Title;
            product.SoldOut = viewModel.SoldOut;
            product.LastUpdateDateTime = DateTime.Now;

            return product;
        }

        private static void AddProductPriceToProduct(EditProductViewModel viewModel, Product product)
        {
            var getLastProductPrice =
                GetLastActiveProductPrice(product);

            if (viewModel.Price == null)
                return;

            if (viewModel.Price == getLastProductPrice?.Price)
                return;

            if (getLastProductPrice != null)
            {
                DisableLastActiveProductPrice(viewModel, product, getLastProductPrice);
            }

            AddFirstProductPriceForProduct(viewModel, product);
        }

        private static void DisableLastActiveProductPrice(EditProductViewModel viewModel, Product product, ProductPrice getLastProductPrice)
        {
            getLastProductPrice.EndDateTime = DateTime.Now;
        }

        private static void AddFirstProductPriceForProduct(EditProductViewModel viewModel, Product product)
        {
            product.ProductPrices
                .Add(
                    new ProductPrice
                    {
                        Price = viewModel.Price.Value,
                        StartDateTime = DateTime.Now
                    }
                );
        }

        private static ProductPrice GetLastActiveProductPrice(Product product)
        {
            var getLastProductPrice =
                product.ProductPrices?
                    .OrderByDescending(o => o.StartDateTime)
                    .FirstOrDefault();

            return getLastProductPrice;
        }

        public async Task<bool> UpdateProductToDb(Product product)
        {
            try
            {
                StoreDbContext.Products
                    .Update(product);

                await StoreDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
