#pragma checksum "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\GetScheduleTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea18d6e1c1c0d9f64f8ec66f89e647620e307910"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetScheduleTable), @"mvc.1.0.view", @"/Views/Home/GetScheduleTable.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/GetScheduleTable.cshtml", typeof(AspNetCore.Views_Home_GetScheduleTable))]
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
#line 1 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\_ViewImports.cshtml"
using Task_Manager;

#line default
#line hidden
#line 2 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\_ViewImports.cshtml"
using Task_Manager.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea18d6e1c1c0d9f64f8ec66f89e647620e307910", @"/Views/Home/GetScheduleTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f84600d5c7218bee7acb34bd22834a435de08af5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetScheduleTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<List<string>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\GetScheduleTable.cshtml"
  
    ViewData["Title"] = "GetScheduleTable";

#line default
#line hidden
            BeginContext(82, 38, true);
            WriteLiteral("<h2>GetScheduleTable</h2>\r\n\r\n<table>\r\n");
            EndContext();
#line 9 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\GetScheduleTable.cshtml"
     for (int i = 0; i < Model.Count; i++)
    {

#line default
#line hidden
            BeginContext(171, 10, true);
            WriteLiteral("    <tr>\r\n");
            EndContext();
#line 12 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\GetScheduleTable.cshtml"
         for (int j = 0; j < Model[i].Count; j++)
        {

#line default
#line hidden
            BeginContext(243, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(260, 11, false);
#line 14 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\GetScheduleTable.cshtml"
           Write(Model[i][j]);

#line default
#line hidden
            EndContext();
            BeginContext(271, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 15 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\GetScheduleTable.cshtml"
        }

#line default
#line hidden
            BeginContext(289, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
#line 17 "D:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\GetScheduleTable.cshtml"
    }

#line default
#line hidden
            BeginContext(307, 12, true);
            WriteLiteral("</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<List<string>>> Html { get; private set; }
    }
}
#pragma warning restore 1591