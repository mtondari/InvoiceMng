#pragma checksum "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b4b99e6b4a24d83cd2c03c71b2b02bab6313735"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/Index.cshtml", typeof(AspNetCore.Views_Products_Index))]
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
#line 1 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
using StoreManagement.ViewModels.Products;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b4b99e6b4a24d83cd2c03c71b2b02bab6313735", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2811a0c7a0d4500d1d3cbe872abef4065004b8dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(75, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "???????????? ??????????????";

#line default
#line hidden
            BeginContext(127, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(134, 17, false);
#line 9 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(151, 37, true);
            WriteLiteral("</h1>\r\n\r\n<a class=\"button add-button\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 188, "\"", 224, 1);
#line 11 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
WriteAttributeValue("", 195, Url.Action("Add","Products"), 195, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(225, 23, true);
            WriteLiteral(">?????? ?????????? ????????</a>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(278, 75, true);
            WriteLiteral("    <div>\r\n        <ul class=\"search-section\">\r\n            <li>?????? ??????????: ");
            EndContext();
            BeginContext(354, 33, false);
#line 17 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
                      Write(Html.EditorFor(o => o.SearchWord));

#line default
#line hidden
            EndContext();
            BeginContext(387, 39, true);
            WriteLiteral("</li>\r\n            <li>?????????? ???? ??????????: ");
            EndContext();
            BeginContext(427, 64, false);
#line 18 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
                           Write(Html.DropDownListFor(o => o.SoldOut, Model.SoldOutOptions,"??????"));

#line default
#line hidden
            EndContext();
            BeginContext(491, 147, true);
            WriteLiteral("</li>\r\n            <li>\r\n                <button type=\"submit\" class=\"button search\">??????????</button>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n");
            EndContext();
#line 24 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
}

#line default
#line hidden
            BeginContext(641, 324, true);
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <th>??????</th>
            <th>??????????????</th>
            <th>???????? (????????)</th>
            <th>?????????? ???? ??????????</th>
            <th>?????????? ??????????</th>
            <th>?????????? ?????????? ??????????</th>
            <th>????????????</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 39 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
         foreach (var product in Model.Products)
        {

#line default
#line hidden
            BeginContext(1026, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1065, 13, false);
#line 42 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
               Write(product.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1078, 29, true);
            WriteLiteral("</td>\r\n                <td>\r\n");
            EndContext();
#line 44 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
                     if (product.Description.Length > 250)
                    {
                        

#line default
#line hidden
            BeginContext(1215, 34, false);
#line 46 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
                   Write(product.Description.Substring(250));

#line default
#line hidden
            EndContext();
            BeginContext(1256, 3, true);
            WriteLiteral("...");
            EndContext();
#line 46 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
                                                                            
                    }
                    else
                    {
                        

#line default
#line hidden
            BeginContext(1365, 19, false);
#line 50 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
                   Write(product.Description);

#line default
#line hidden
            EndContext();
#line 50 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
                                            
                    }

#line default
#line hidden
            BeginContext(1409, 43, true);
            WriteLiteral("                </td>\r\n                <td>");
            EndContext();
            BeginContext(1453, 16, false);
#line 53 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
               Write(product.PriceStr);

#line default
#line hidden
            EndContext();
            BeginContext(1469, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1497, 18, false);
#line 54 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
               Write(product.SoldOutStr);

#line default
#line hidden
            EndContext();
            BeginContext(1515, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1543, 25, false);
#line 55 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
               Write(product.CreateDateTimeStr);

#line default
#line hidden
            EndContext();
            BeginContext(1568, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1596, 29, false);
#line 56 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
               Write(product.LastUpdateDateTimeStr);

#line default
#line hidden
            EndContext();
            BeginContext(1625, 51, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1676, "\"", 1744, 1);
#line 58 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
WriteAttributeValue("", 1683, Url.Action("Edit","Products",new { id = product.ProductId }), 1683, 61, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1745, 103, true);
            WriteLiteral(">\r\n                        ????????????\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 63 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Products\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1859, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
