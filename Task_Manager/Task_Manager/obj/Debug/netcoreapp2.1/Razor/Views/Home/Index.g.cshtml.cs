#pragma checksum "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29d49011307e7571ce490f05b608b2af502d7d10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\_ViewImports.cshtml"
using Task_Manager;

#line default
#line hidden
#line 2 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\_ViewImports.cshtml"
using Task_Manager.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29d49011307e7571ce490f05b608b2af502d7d10", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f84600d5c7218bee7acb34bd22834a435de08af5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Task_Manager.Models.DtoForIndex>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(86, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
 foreach (var item in Model.Childs)
{

#line default
#line hidden
            BeginContext(128, 4, true);
            WriteLiteral("<h4>");
            EndContext();
            BeginContext(133, 9, false);
#line 8 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(142, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(144, 12, false);
#line 8 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
          Write(item.Surname);

#line default
#line hidden
            EndContext();
            BeginContext(156, 25, true);
            WriteLiteral("   должен сделать </h4>\r\n");
            EndContext();
#line 9 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
     foreach (var task in Model.TasksToday[item])
    {

#line default
#line hidden
            BeginContext(239, 8, true);
            WriteLiteral("    <h5>");
            EndContext();
            BeginContext(248, 25, false);
#line 11 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
   Write(task.TaskElement.TaskName);

#line default
#line hidden
            EndContext();
            BeginContext(273, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(275, 29, false);
#line 11 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
                              Write(task.TaskElement.TaskCategory);

#line default
#line hidden
            EndContext();
            BeginContext(304, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(306, 26, false);
#line 11 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
                                                             Write(task.StatusTask.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(332, 8, true);
            WriteLiteral(" </h5>\r\n");
            EndContext();
#line 12 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#line 12 "d:\C#\SimbirSoft_Summer_intensive\Task_Manager\Task_Manager\Views\Home\Index.cshtml"
     

}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Task_Manager.Models.DtoForIndex> Html { get; private set; }
    }
}
#pragma warning restore 1591
