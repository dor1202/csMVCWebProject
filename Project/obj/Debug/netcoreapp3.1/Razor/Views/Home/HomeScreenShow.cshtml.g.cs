#pragma checksum "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbc4516138fee4b3163cd2b34688720e907ed842"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HomeScreenShow), @"mvc.1.0.view", @"/Views/Home/HomeScreenShow.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbc4516138fee4b3163cd2b34688720e907ed842", @"/Views/Home/HomeScreenShow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_HomeScreenShow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project.Models.HomeModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml"
  
    ViewBag.Title = "Starting Screen";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""badge badge-primary text-wrap"">Top 2 most reviewed animals are:</div>

<table class=""table table-striped table-dark"">
    <thead>
        <tr>
            <th scope=""col"">Image</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Content</th>
            <th scope=""col"">Number of comments</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    <img");
            BeginWriteAttribute("src", " src=\"", 610, "\"", 675, 2);
            WriteAttributeValue("", 616, "data:image/jpg;base64,", 616, 22, true);
#nullable restore
#line 24 "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml"
WriteAttributeValue(" ", 638, Convert.ToBase64String(@item.Photo), 639, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n                </td>\n                <td>");
#nullable restore
#line 26 "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 27 "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml"
               Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 28 "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml"
               Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 30 "\\Mac\Home\Desktop\csMVCWebProject\Project\Views\Home\HomeScreenShow.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<div class=""d-flex justify-content-center"" style =""background: rgb(204, 204, 204); /* Fallback for older browsers without RGBA-support */
                background: rgba(204, 204, 204, 0.2);
                border-radius:4px;"">

    <blockquote class=""blockquote text-center"">
        <p class=""mb-0"" style=""color:lightgrey"">Rescue: it's not just a verb, it's a promise.</p>
        <footer class=""blockquote-footer"">Writen by: <cite title=""Source Title"">Google</cite></footer>
    </blockquote>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project.Models.HomeModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
