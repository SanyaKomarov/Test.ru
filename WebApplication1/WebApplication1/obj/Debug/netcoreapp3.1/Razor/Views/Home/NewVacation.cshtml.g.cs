#pragma checksum "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c9dcf40067d7cb51bac0d381466ae46371703f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_NewVacation), @"mvc.1.0.view", @"/Views/Home/NewVacation.cshtml")]
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
#line 1 "D:\тесты\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\тесты\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c9dcf40067d7cb51bac0d381466ae46371703f5", @"/Views/Home/NewVacation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_NewVacation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.Controllers.Vacation>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
  
    ViewBag.Title = "Новый отпуск";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Новый отпуск</h2>\r\n\r\n");
#nullable restore
#line 9 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
 using (Html.BeginForm("CreateVacation", "Home", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-group\">\r\n    ");
#nullable restore
#line 14 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
Write(Html.LabelFor(m => m.Employee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 15 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
Write(Html.DropDownListFor(m => m.EmployeeId, (SelectList)ViewBag.Employees, "Выберите сотрудника", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 16 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
Write(Html.ValidationMessageFor(m => m.Employee.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 20 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
   Write(Html.LabelFor(m => m.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 21 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
   Write(Html.TextBoxFor(m => m.StartDate, new { type = "date", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 22 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
   Write(Html.ValidationMessageFor(m => m.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 26 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
   Write(Html.LabelFor(m => m.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 27 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
   Write(Html.TextBoxFor(m => m.EndDate, new { type = "date", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 28 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
   Write(Html.ValidationMessageFor(m => m.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Отправить</button>\r\n");
#nullable restore
#line 32 "D:\тесты\WebApplication1\WebApplication1\Views\Home\NewVacation.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Controllers.Vacation> Html { get; private set; }
    }
}
#pragma warning restore 1591