#pragma checksum "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c38eb955b73e13b73b774b0a7678f1e2d46a2a9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoices_Add), @"mvc.1.0.view", @"/Views/Invoices/Add.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Invoices/Add.cshtml", typeof(AspNetCore.Views_Invoices_Add))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\_ViewImports.cshtml"
using StoreManagement;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\_ViewImports.cshtml"
using StoreManagement.ViewModels;

#line default
#line hidden
#line 1 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
using StoreManagement.ViewModels.Invoices;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c38eb955b73e13b73b774b0a7678f1e2d46a2a9a", @"/Views/Invoices/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2811a0c7a0d4500d1d3cbe872abef4065004b8dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoices_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddInvoiceViewModel>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(74, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
  
    ViewData["Title"] = "?????? ?????????? ????????";

#line default
#line hidden
            BeginContext(126, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(158, 8, true);
            WriteLiteral("    <h1>");
            EndContext();
            BeginContext(167, 17, false);
#line 11 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(184, 123, true);
            WriteLiteral("</h1>\r\n    <table class=\"table\">\r\n        <tbody>\r\n            <tr>\r\n                <td>??????????????</td>\r\n                <td>");
            EndContext();
            BeginContext(308, 44, false);
#line 16 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
               Write(Html.TextAreaFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(352, 102, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>?????????? ??????????</td>\r\n                <td>");
            EndContext();
            BeginContext(455, 63, false);
#line 20 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
               Write(Html.DropDownListFor(model => model.Status,Model.StatusOptions));

#line default
#line hidden
            EndContext();
            BeginContext(518, 1369, true);
            WriteLiteral(@"</td>
            </tr>
            <tr>
                <td colspan=""2"">
                    <h3 style=""text-align:center;"">???????????? ??????????</h3>
                    <table class=""invoice-items"">
                        <thead>
                            <tr>
                                <th>??????????</th>
                                <th>??????????</th>
                                <th>???????? ???????? (????????)</th>
                                <th>???????? ?????????? (????????)</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                        <tfoot>
                            <tr>
                                <td colspan=""4"">
                                    <button type=""button"" title=""?????? ?????????? ????????"" onclick=""AddInvoiceItemRow();"">
                                        ?????? ???????? ????????
                                    </button>
                                </td>
                            </tr>
                        </");
            WriteLiteral(@"tfoot>
                    </table>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan=""2"">
                    <button type=""submit"">
                        ??????
                    </button>
                </td>
            </tr>
        </tfoot>
    </table>
");
            EndContext();
            BeginContext(1889, 37, true);
            WriteLiteral("    <datalist id=\"active-products\">\r\n");
            EndContext();
#line 60 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
         foreach (var product in Model.ActiveProductOptions)
        {

#line default
#line hidden
            BeginContext(1999, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2011, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7470d7fd1a5740b28a76029b76d76d95", async() => {
                BeginContext(2096, 13, false);
#line 62 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
                                                                                           Write(product.Title);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 62 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
                           Write(product.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-value", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 62 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
                                                    Write(product.Price.ToPersianPriceString());

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-price", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2118, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 63 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
        }

#line default
#line hidden
            BeginContext(2131, 17, true);
            WriteLiteral("    </datalist>\r\n");
            EndContext();
#line 65 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Add.cshtml"
}

#line default
#line hidden
            BeginContext(2151, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2178, 2453, true);
                WriteLiteral(@"
    <script>
        function AddInvoiceItemRow() {
            $(document).ready(function () {
                var newTr = '<tr><td><input list=""active-products"" placeholder=""?????? ?????????? ...""><input type=""hidden"" name=""product__id""></td><td><input type=""number"" name=""product__count""></td><td class=""priceStr""></td><td><input type=""number"" name=""product__final""></td></tr>'
                $('.invoice-items tbody').append(newTr);

                var row = $('.invoice-items tbody tr').last();

                $(row).find('input[list]')[0].addEventListener('input', function (e) {
                    var input = e.target,
                        list = input.getAttribute('list'),
                        options = document.querySelectorAll('#' + list + ' option');
                    
                    $($(row).find('[name=""product__count""]')[0].parentElement.parentElement).find('.priceStr').text();

                    inputValue = input.value;

                    for (var i = 0; i < options.l");
                WriteLiteral(@"ength; i++) {
                        var option = options[i];

                        if (option.innerText === inputValue) {
                            $($(input.parentElement.parentElement).find('[name=""product__id""]')).val(option.getAttribute('data-value'));
                            
                            $(input.parentElement.parentElement).find('td.priceStr').text(option.getAttribute('data-price'))

                            var count = $($(row).find('[name=""product__count""]')[0]).val();
                            var price = parseInt(row.find('.priceStr').text().replace(' ????????', '').replace(',', ''));

                            $($(row).find('[name=""product__final""]')[0]).val(count * price);
                            break;
                        }
                    }
                });

                $(row).find('[name=""product__count""]')[0].addEventListener('input', function (e) {
                    var input = e.target,
                        list = input.");
                WriteLiteral(@"getAttribute('list');

                    var count = $($(row).find('[name=""product__count""]')[0]).val();
                    var price = parseInt(row.find('.priceStr').text().replace(' ????????', '').replace(',', ''));

                    $($(row).find('[name=""product__final""]')[0]).val(count * price);
                    
                });
            });
        }
        
    </script>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddInvoiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
