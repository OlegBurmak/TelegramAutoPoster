#pragma checksum "D:\C#Projects\ASP.NET Core\TAPoster\Views\Shared\PostsSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "169a37f9b20af3ce166067f65713481e57cf1ad4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PostsSummary), @"mvc.1.0.view", @"/Views/Shared/PostsSummary.cshtml")]
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
#line 1 "D:\C#Projects\ASP.NET Core\TAPoster\Views\_ViewImports.cshtml"
using TAPoster;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#Projects\ASP.NET Core\TAPoster\Views\_ViewImports.cshtml"
using TAPoster.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"169a37f9b20af3ce166067f65713481e57cf1ad4", @"/Views/Shared/PostsSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ae2edc7228bd142bc1963e7dc54780e2d304b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PostsSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VkPostItem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n  <div class=\"card-header\">\r\n    ");
#nullable restore
#line 6 "D:\C#Projects\ASP.NET Core\TAPoster\Views\Shared\PostsSummary.cshtml"
Write(Model.PostType);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Тип поста\r\n  </div>\r\n  <div class=\"card-body\">\r\n    <h5 class=\"card-title\">");
#nullable restore
#line 9 "D:\C#Projects\ASP.NET Core\TAPoster\Views\Shared\PostsSummary.cshtml"
                      Write(Model.Url);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n    <p class=\"card-text\">");
#nullable restore
#line 10 "D:\C#Projects\ASP.NET Core\TAPoster\Views\Shared\PostsSummary.cshtml"
                    Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p class=\"card-text\">");
#nullable restore
#line 11 "D:\C#Projects\ASP.NET Core\TAPoster\Views\Shared\PostsSummary.cshtml"
                    Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Дата</p>\r\n  </div>\r\n  <input type=\"hidden\" name=\"Text\" />\r\n  <input type=\"hidden\" name=\"Url\" />\r\n  <input type=\"hidden\" name=\"PostType\" />\r\n  <input type=\"hidden\" name=\"Date\" />\r\n  <input type=\"hidden\" name=\"TypeAttachment\" />\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VkPostItem> Html { get; private set; }
    }
}
#pragma warning restore 1591
