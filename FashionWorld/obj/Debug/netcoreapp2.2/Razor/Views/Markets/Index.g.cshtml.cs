#pragma checksum "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfbe868aebdb0bfe3e59e42372fcebeb61d48e9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Markets_Index), @"mvc.1.0.view", @"/Views/Markets/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Markets/Index.cshtml", typeof(AspNetCore.Views_Markets_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfbe868aebdb0bfe3e59e42372fcebeb61d48e9b", @"/Views/Markets/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d519d9c44693718d0114df6a551305ee8cce0352", @"/Views/_ViewImports.cshtml")]
    public class Views_Markets_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FashionWorld.Models.Market>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
  
    ViewData["Title"] = "Markets";
    

#line default
#line hidden
#line 5 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
     if (User.Identity.IsAuthenticated)
    {
        if (User.IsInRole("Admins"))
        {
            Layout = "~/Views/Shared/_AdminLayout.cshtml";
        }
        else if (User.IsInRole("Market Owner"))
        {
            Layout = "~/Views/Shared/_MarketOwnerLayout.cshtml";
        }
    }

#line default
#line hidden
            BeginContext(405, 51, true);
            WriteLiteral("\r\n<h1 class=\"text-center\">Markets</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(456, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfbe868aebdb0bfe3e59e42372fcebeb61d48e9b6449", async() => {
                BeginContext(503, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(517, 123, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table mt-2\">\r\n    <thead class=\"bg-info text-dark\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(641, 46, false);
#line 27 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MarketName));

#line default
#line hidden
            EndContext();
            BeginContext(687, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(743, 48, false);
#line 30 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Descripshion));

#line default
#line hidden
            EndContext();
            BeginContext(791, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(847, 47, false);
#line 33 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MarketOwner));

#line default
#line hidden
            EndContext();
            BeginContext(894, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(950, 49, false);
#line 36 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.MarketAddress));

#line default
#line hidden
            EndContext();
            BeginContext(999, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1055, 41, false);
#line 39 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FBUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 88, true);
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 46 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1233, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1294, 45, false);
#line 50 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MarketName));

#line default
#line hidden
            EndContext();
            BeginContext(1339, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1407, 47, false);
#line 53 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Descripshion));

#line default
#line hidden
            EndContext();
            BeginContext(1454, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1522, 46, false);
#line 56 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MarketOwner));

#line default
#line hidden
            EndContext();
            BeginContext(1568, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1636, 48, false);
#line 59 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.MarketAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1684, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1752, 40, false);
#line 62 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FBUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1792, 69, true);
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1861, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfbe868aebdb0bfe3e59e42372fcebeb61d48e9b12758", async() => {
                BeginContext(1936, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 66 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
                                           WriteLiteral(item.MarketID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1944, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1968, 86, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfbe868aebdb0bfe3e59e42372fcebeb61d48e9b15204", async() => {
                BeginContext(2044, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 67 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
                                             WriteLiteral(item.MarketID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2054, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 70 "F:\PICTI\FashionWorld\Backend\FashionWorld\FashionWorld\Views\Markets\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2109, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FashionWorld.Models.Market>> Html { get; private set; }
    }
}
#pragma warning restore 1591
