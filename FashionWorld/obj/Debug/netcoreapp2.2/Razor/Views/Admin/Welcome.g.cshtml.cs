#pragma checksum "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Admin\Welcome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8e58e7f3e708e76256b73f16a8bd1ffe80d9c7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Welcome), @"mvc.1.0.view", @"/Views/Admin/Welcome.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Welcome.cshtml", typeof(AspNetCore.Views_Admin_Welcome))]
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
#line 1 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\_ViewImports.cshtml"
using FashionWorld;

#line default
#line hidden
#line 2 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\_ViewImports.cshtml"
using FashionWorld.Models;

#line default
#line hidden
#line 3 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\_ViewImports.cshtml"
using FashionWorld.Models.ViewModels;

#line default
#line hidden
#line 4 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 5 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\_ViewImports.cshtml"
using FashionWorld.Infrastructure;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8e58e7f3e708e76256b73f16a8bd1ffe80d9c7e", @"/Views/Admin/Welcome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d519d9c44693718d0114df6a551305ee8cce0352", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Welcome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Admin\Welcome.cshtml"
  
    ViewData["Title"] = "Admin - Welcome";

    

#line default
#line hidden
#line 5 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Admin\Welcome.cshtml"
     if (User.Identity.IsAuthenticated)
    {
        if (User.IsInRole("Admins"))
        {
            Layout = "~/Views/Shared/_AdminLayout.cshtml";
        }
        else if (User.IsInRole("Market Owner"))
        {
            Layout = "~/Views/Shared/_MarketOwnerLayout.cshtml";
        }else if (User.IsInRole("Customer"))
        {
            Layout = "~/Views/Shared/_CustomerLayout.cshtml";
        }
    }

#line default
#line hidden
            BeginContext(485, 190, true);
            WriteLiteral("\r\n<h1 class=\"text-secondary text-center my-5\">Welcome to Your Dashboard Area</h1>\r\n<p class=\"lead text-capitalize text-center  mt-5 p-10\">Easy to use dashboard and manage your Acount</p>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591