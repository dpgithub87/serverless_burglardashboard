// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "c:\Project_Learning\BlazorApp\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Project_Learning\BlazorApp\BlazorApp\Pages\Index.razor"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\Project_Learning\BlazorApp\BlazorApp\Pages\Index.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "c:\Project_Learning\BlazorApp\BlazorApp\Pages\Index.razor"
       
   
   private AuthorisationRequest[] originalAuthorisations;
    private AuthorisationRequest[] authorisations;
    private string SearchText = "";
    private string FreeText = "";
    protected override async Task OnInitializedAsync()
    {
        HttpResponseMessage response = await Http.GetAsync("http://localhost:7071/api/BCSC3AuthSupport");
        var responseContent = await response.Content.ReadAsStringAsync();
        originalAuthorisations = JsonConvert.DeserializeObject<List<AuthorisationRequest>>(responseContent).ToArray();
        authorisations = originalAuthorisations; 
    }  

    private void Search()
    {
        authorisations = originalAuthorisations;

        if (SearchText != "")
        {
         authorisations = originalAuthorisations.Where(x => x.LicensePlate.Contains(SearchText)).ToArray();
        }
    }

    private void SearchFreeText() //string value
    {
       // FreeText = value;
        authorisations = originalAuthorisations;

        if (FreeText != "")
        {
         authorisations = originalAuthorisations.Where(x => x.LicensePlate.Contains(FreeText)
         || x.AuthorisationReference.Contains(FreeText))
         .ToArray();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
