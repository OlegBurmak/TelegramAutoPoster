#pragma checksum "D:\C#Projects\ASP.NET Core\TAPoster\Views\Post\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1a8a26dd6759f4038f9748fe44affe411384101"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Posts), @"mvc.1.0.view", @"/Views/Post/Posts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1a8a26dd6759f4038f9748fe44affe411384101", @"/Views/Post/Posts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24ae2edc7228bd142bc1963e7dc54780e2d304b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Posts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<VkPostItem>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\C#Projects\ASP.NET Core\TAPoster\Views\Post\Posts.cshtml"
 foreach(var item in Model)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\C#Projects\ASP.NET Core\TAPoster\Views\Post\Posts.cshtml"
Write(await Html.PartialAsync("PostsSummary", item));

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\C#Projects\ASP.NET Core\TAPoster\Views\Post\Posts.cshtml"
                                                  
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<VkPostItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
