#pragma checksum "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/Order/Charge.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5933111f809320bdd6c9df6819a54c92a7961ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Charge), @"mvc.1.0.view", @"/Views/Order/Charge.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5933111f809320bdd6c9df6819a54c92a7961ae", @"/Views/Order/Charge.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b325dbb5907b7ec89df472d4f5bf697ea54243a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Charge : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4 class=\"category-title\">Pay Now</h4>\r\n<br />\r\n\r\n<h4>Total amount to pay: &pound;");
#nullable restore
#line 5 "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/Order/Charge.cshtml"
                           Write(ViewBag.shoppingCartTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
<a runat=""server"" id=""pay-now"" class=""btn btn-info"" style=""color: white; cursor:pointer"" ClientIDMode=""Static"">Pay Now</a>
<script src=""https://js.stripe.com/v2/""></script>
<script src=""https://js.stripe.com/v3/""></script>
<script>
    var stripe = Stripe('");
#nullable restore
#line 10 "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/Order/Charge.cshtml"
                    Write(ViewBag.stripePublishableKey);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    var payBtn = document.getElementById(\'pay-now\');\r\n\r\n    payBtn.addEventListener(\'click\', function () {\r\n        stripe.redirectToCheckout({\r\n            sessionId: \'");
#nullable restore
#line 15 "/Users/cheryl/Documents/My Docs/Cheryl/Projects/TextBooky/TextBooky/Views/Order/Charge.cshtml"
                   Write(ViewBag.sessionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'\r\n        });\r\n    });\r\n</script>\r\n\r\n");
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
