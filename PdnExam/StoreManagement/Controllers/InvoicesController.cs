using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataBaseRepository;
using DataBaseRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Common.ExtensionMethods;
using StoreManagement.ViewModels;
using StoreManagement.ViewModels.Invoices;
using StoreManagement.ViewModels.Products;

namespace StoreManagement.Controllers
{
    public class InvoicesController : BaseController
    {
        public InvoicesController(StoreDbContext storeDbContext)
            : base(storeDbContext)
        {

        }

        #region Index

        public async Task<IActionResult> Index(InvoiceListViewModel model)
        {
            var invoices = await FetchInvoicesFromDb(model);

            FillInvoiceListItemViewModelFromDbInvoices(model, invoices);

            return View(model);
        }

        private async Task<List<Invoice>> FetchInvoicesFromDb(InvoiceListViewModel model)
        {
            return
                await StoreDbContext.Invoices
                    .Where(o =>
                        model.SearchWord == null ||
                        o.Description.Contains(model.SearchWord)
                    )
                    .ToListAsync();
        }

        private static void FillInvoiceListItemViewModelFromDbInvoices(InvoiceListViewModel model, List<Invoice> invoices)
        {
            model.Invoices =
                invoices.Select(o =>
                    new InvoiceListItemViewModel
                    {
                        CreateDateTime = o.CreateDateTime,
                        Description = o.Description,
                        InvoiceId = o.Id,
                        Status = o.Status,
                        FinalPrice = o.FinalPrice
                    }
                )
                .ToList();
        }

        #endregion

        #region AddInvoice

        public async Task<IActionResult> Add()
        {
            var viewModel = new AddInvoiceViewModel();

            viewModel.ActiveProductOptions =
                await FetchActiveProducts();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInvoiceViewModel viewModel, IFormCollection formCollection)
        {
            var invoice =
                await GenerateInvoiceFromViewModelAndFormCollection(viewModel, formCollection);

            viewModel.ActiveProductOptions =
                await FetchActiveProducts();

            viewModel.ErrorMessages =
                ValidatePrices(invoice);

            if (viewModel.ErrorMessages?.Count > 0)
                return View(viewModel);

            if (!(await InsertInvoiceToDb(invoice)))
            {
                viewModel.ErrorMessages
                    .Add("عملیات درج محصول با خطا مواجه شد، لطفا مجدد تلاش نمایید.");

                return View(viewModel);
            }

            TempData["SuccessMessage"] = "درج محصول با موفقیت انجام شد.";

            return RedirectToAction("Index");
        }

        private async Task<Invoice> GenerateInvoiceFromViewModelAndFormCollection(AddInvoiceViewModel viewModel, IFormCollection formCollection)
        {
            var invoice = GenerateInvoiceFromViewModel(viewModel);

            invoice.InvoiceItems =
                await GenerateInvoiceItemsFromFormCollection(formCollection);

            UpdateInvoicePrice(invoice);

            return invoice;
        }

        private Invoice GenerateInvoiceFromViewModel(AddInvoiceViewModel viewModel)
        {
            return
                new Invoice
                {
                    CreateDateTime = DateTime.Now,
                    Description = viewModel.Description,
                    FinalPrice = viewModel.FinalPrice,
                    Status = viewModel.Status
                };
        }

        private async Task<List<InvoiceItem>> GenerateInvoiceItemsFromFormCollection(IFormCollection formCollection)
        {
            if (formCollection["product__id"].Count < 1)
                return new List<InvoiceItem>();

            FetchProductId_ProductCount_ProductFinalPrice_FromFormCollection(
                formCollection, out int[] productIds, out int[] productCounts, out int[] productFinalPrices);

            var items =
                await GenerateInvoiceItemByUserInputes(productIds, productCounts, productFinalPrices);

            return items;
        }

        private async Task<bool> InsertInvoiceToDb(Invoice invoice)
        {
            try
            {
                await StoreDbContext.Invoices
                    .AddAsync(invoice);

                await StoreDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region EditInvoice

        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await FetchInvoiceFromDb(id);

            var viewModel =
                GenerateViewModel(invoice);

            viewModel.ActiveProductOptions =
                await FetchActiveProducts();

            FillInvoiceItemsOfViewModel(invoice, viewModel);

            return View(viewModel);
        }

        private async Task<Invoice> FetchInvoiceFromDb(int id)
        {
            return
                await StoreDbContext.Invoices
                    .Include("InvoiceItems.Product")
                    .Include("InvoiceItems.ProductPrice")
                    .FirstOrDefaultAsync(o => o.Id == id);
        }

        private static EditInvoiceViewModel GenerateViewModel(Invoice invoice)
        {
            return new EditInvoiceViewModel
            {
                Description = invoice.Description,
                Status = invoice.Status,
                InvoiceId = invoice.Id,
                FinalPrice = invoice.FinalPrice
            };
        }

        private static void FillInvoiceItemsOfViewModel(Invoice invoice, EditInvoiceViewModel viewModel)
        {
            viewModel.InvoiceItems =
                invoice.InvoiceItems
                    .Select(o =>
                        new AddInvoiceItemViewModel
                        {
                            Count = o.Count,
                            FinalPrice = o.FinalPrice,
                            PriceItem = o.ProductPrice.Price,
                            ProductId = o.ProductId,
                            ProductTitle = o.Product.Title
                        }
                    )
                    .ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditInvoiceViewModel viewModel, IFormCollection formCollection)
        {
            var invoice =
                await FetchInvoiceFromDb(viewModel.InvoiceId);

            await UpdateInvoiceFromViewModelAndFormCollection(invoice, viewModel, formCollection);

            if (invoice == null)
                return NotFound();

            viewModel.ActiveProductOptions =
                await FetchActiveProducts();

            viewModel.ErrorMessages =
                ValidatePrices(invoice);

            if (viewModel.ErrorMessages?.Count > 0)
                return View(viewModel);

            if (!(await UpdateInvoiceToDb(invoice)))
            {
                viewModel.ErrorMessages
                    .Add("عملیات درج محصول با خطا مواجه شد، لطفا مجدد تلاش نمایید.");

                return View(viewModel);
            }

            TempData["SuccessMessage"] = "درج محصول با موفقیت انجام شد.";

            return RedirectToAction("Index");
        }

        private async Task<Invoice> UpdateInvoiceFromViewModelAndFormCollection(Invoice invoice,
            EditInvoiceViewModel viewModel, IFormCollection formCollection)
        {
            invoice = UpdateInvoiceFromViewModel(invoice, viewModel);

            invoice.InvoiceItems.Clear();

            invoice.InvoiceItems =
                await UpdateInvoiceItemsFromFormCollection(invoice, formCollection);

            UpdateInvoicePrice(invoice);

            return invoice;
        }

        private Invoice UpdateInvoiceFromViewModel(Invoice invoice, EditInvoiceViewModel viewModel)
        {
            invoice.Description = viewModel.Description;
            invoice.FinalPrice = viewModel.FinalPrice;
            invoice.Status = viewModel.Status;

            return invoice;
        }

        private async Task<List<InvoiceItem>> UpdateInvoiceItemsFromFormCollection(Invoice invoice, IFormCollection formCollection)
        {
            if (formCollection["product__id"].Count < 1)
                return new List<InvoiceItem>();

            FetchProductId_ProductCount_ProductFinalPrice_FromFormCollection(
                formCollection, out int[] productIds, out int[] productCounts, out int[] productFinalPrices);

            var items =
                await GenerateInvoiceItemByUserInputes(productIds, productCounts, productFinalPrices);

            return items;
        }

        private async Task<bool> UpdateInvoiceToDb(Invoice invoice)
        {
            try
            {
                StoreDbContext.Invoices
                    .Update(invoice);

                await StoreDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        private async Task<List<Product>> FetchActiveProducts()
        {
            return
                await StoreDbContext.Products
                    .Include(o => o.ProductPrices)
                    .Where(o => o.SoldOut == false)
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
        }

        private static void FetchProductId_ProductCount_ProductFinalPrice_FromFormCollection(IFormCollection formCollection, out int[] productIds, out int[] productCounts, out int[] productFinalPrices)
        {
            productIds =
                formCollection["product__id"]
                    .Where(o => !o.IsNullOrEmptyOrWhiteSpace())
                    .Select(o => int.Parse(o))
                    .ToArray();

            productCounts =
                formCollection["product__count"]
                    .Where(o => !o.IsNullOrEmptyOrWhiteSpace())
                    .Select(o => int.Parse(o))
                    .ToArray();

            productFinalPrices =
                formCollection["product__final"]
                    .Where(o => !o.IsNullOrEmptyOrWhiteSpace())
                    .Select(o => int.Parse(o))
                    .ToArray();
        }

        private async Task<List<InvoiceItem>> GenerateInvoiceItemByUserInputes(int[] productIds, int[] productCounts, int[] productFinalPrices)
        {
            var items = new List<InvoiceItem>();
            for (var i = 0; i < productIds.Count(); i++)
            {
                var product =
                    await FetchProductFromDbByProductId(productIds, i);

                if (product == null)
                    continue;

                var invoiceItem =
                    await GenerateInvoiceItem(productCounts, productFinalPrices, productIds, product, i);

                items.Add(invoiceItem);
            }

            return items;
        }

        private async Task<Product> FetchProductFromDbByProductId(int[] productIds, int i)
        {
            var productId = productIds[i];

            var product =
                await StoreDbContext.Products
                    .Include(o => o.ProductPrices)
                    .FirstOrDefaultAsync(o => o.Id == productId);

            return product;
        }

        private async Task<InvoiceItem> GenerateInvoiceItem(int[] productCounts, int[] productFinalPrices,
            int[] productIds, Product product, int i)
        {
            return
                new InvoiceItem
                {
                    Count = productCounts[i],
                    FinalPrice = productFinalPrices[i],
                    ProductId = productIds[i],
                    ProductPriceId =
                        product.ProductPrices
                            .OrderByDescending(o => o.StartDateTime)
                            .FirstOrDefault()
                            .Id
                };
        }

        private void UpdateInvoicePrice(Invoice invoice)
        {
            invoice.FinalPrice =
                invoice.InvoiceItems
                    .Sum(o => o.FinalPrice);
        }

        private List<string> ValidatePrices(Invoice invoice)
        {
            var errorMessage = new List<string>();

            if (invoice.FinalPrice < 0)
                errorMessage.Add("مبلغ فاکتور نامعتبر است.");

            if (invoice.InvoiceItems.Any(o => o.FinalPrice < 0))
                errorMessage.Add("مبلغ اقلام فاکتور نامعتبر است.");

            return errorMessage;
        }

    }
}
