#pragma checksum "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9ab11a5549ad4bf9c7ab688fe55ba4815cadb36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoices_Index), @"mvc.1.0.view", @"/Views/Invoices/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Invoices/Index.cshtml", typeof(AspNetCore.Views_Invoices_Index))]
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
#line 1 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
using StoreManagement.ViewModels.Invoices;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9ab11a5549ad4bf9c7ab688fe55ba4815cadb36", @"/Views/Invoices/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2811a0c7a0d4500d1d3cbe872abef4065004b8dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Invoices_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvoiceListViewModel>
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
#line 5 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
  
    ViewData["Title"] = "???????????? ??????????????";

#line default
#line hidden
            BeginContext(127, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(134, 17, false);
#line 9 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(151, 37, true);
            WriteLiteral("</h1>\r\n\r\n<a class=\"button add-button\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 188, "\"", 224, 1);
#line 11 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
WriteAttributeValue("", 195, Url.Action("Add","Invoices"), 195, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(225, 23, true);
            WriteLiteral(">?????? ?????????? ????????</a>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(278, 75, true);
            WriteLiteral("    <div>\r\n        <ul class=\"search-section\">\r\n            <li>?????? ??????????: ");
            EndContext();
            BeginContext(354, 33, false);
#line 17 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
                      Write(Html.EditorFor(o => o.SearchWord));

#line default
#line hidden
            EndContext();
            BeginContext(387, 147, true);
            WriteLiteral("</li>\r\n            <li>\r\n                <button type=\"submit\" class=\"button search\">??????????</button>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n");
            EndContext();
#line 23 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
}

#line default
#line hidden
            BeginContext(537, 249, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>???????? (????????)</th>\r\n            <th>??????????</th>\r\n            <th>?????????? ??????????</th>\r\n            <th>??????????????</th>\r\n            <th>????????????</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 36 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
         foreach (var invoice in Model.Invoices)
        {

#line default
#line hidden
            BeginContext(847, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(886, 21, false);
#line 39 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
               Write(invoice.FinalPriceStr);

#line default
#line hidden
            EndContext();
            BeginContext(907, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(935, 17, false);
#line 40 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
               Write(invoice.StatusStr);

#line default
#line hidden
            EndContext();
            BeginContext(952, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(980, 25, false);
#line 41 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
               Write(invoice.CreateDateTimeStr);

#line default
#line hidden
            EndContext();
            BeginContext(1005, 29, true);
            WriteLiteral("</td>\r\n                <td>\r\n");
            EndContext();
#line 43 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
                     if (invoice.Description?.Length > 250)
                    {
                        

#line default
#line hidden
            BeginContext(1143, 34, false);
#line 45 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
                   Write(invoice.Description.Substring(250));

#line default
#line hidden
            EndContext();
            BeginContext(1184, 3, true);
            WriteLiteral("...");
            EndContext();
#line 45 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
                                                                            
                    }
                    else
                    {
                        

#line default
#line hidden
            BeginContext(1293, 19, false);
#line 49 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
                   Write(invoice.Description);

#line default
#line hidden
            EndContext();
#line 49 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
                                            
                    }

#line default
#line hidden
            BeginContext(1337, 67, true);
            WriteLiteral("                </td>\r\n                <td>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1404, "\"", 1472, 1);
#line 53 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
WriteAttributeValue("", 1411, Url.Action("Edit","Invoices",new { id = invoice.InvoiceId }), 1411, 61, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1473, 103, true);
            WriteLiteral(">\r\n                        ????????????\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 58 "C:\Users\User\source\repos\PdnExam\StoreManagement\Views\Invoices\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1587, 22, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvoiceListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
