#pragma checksum "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/Order/CheckoutComplete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9821443aa56055887aea41c45aba8c5edb0593b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_CheckoutComplete), @"mvc.1.0.view", @"/Views/Order/CheckoutComplete.cshtml")]
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
#nullable restore
#line 1 "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/_ViewImports.cshtml"
using TextBooky;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/_ViewImports.cshtml"
using TextBooky.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/_ViewImports.cshtml"
using TextBooky.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9821443aa56055887aea41c45aba8c5edb0593b", @"/Views/Order/CheckoutComplete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b325dbb5907b7ec89df472d4f5bf697ea54243a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_CheckoutComplete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1 class=\"category-title\">");
#nullable restore
#line 1 "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/Order/CheckoutComplete.cshtml"
                      Write(ViewBag.CheckoutCompleteMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n<h4>You should recieve a confirmation email soon</h4>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591