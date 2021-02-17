// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace blazorapp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using blazorapp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\_Imports.razor"
using blazorapp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\Pages\Index.razor"
using BlazorApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\Pages\Index.razor"
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
#line 44 "K:\Work\Github\serverless_burglardashboard\BlazorApp1\blazorapp\Pages\Index.razor"
       
   
   private BoardTransaction[] originalTransactions;
    private BoardTransaction[] filteredTransactions;
    private string SearchText = "";
    private string FreeText = "";
    protected override async Task OnInitializedAsync()
    {
        var response = await Http.GetFromJsonAsync<BoardTransaction[]>("sample-data/Sample_BoardTransaction.json");
        originalTransactions = response;
        filteredTransactions = originalTransactions;
        //HttpResponseMessage response = await Http.GetAsync("https://burglarboarddata.azurewebsites.net/api/BoardData?code=rMbVg6gfT7naJ7w4aQFajpzaHQxJztZWW7ESQguCIW52SaGytxGkqg==");
        //var responseContent = await response.Content.ReadAsStringAsync();
        //originalTransactions = JsonConvert.DeserializeObject<List<BoardTransaction>>(response).ToArray();
        //filteredTransactions = originalTransactions; 
    }  

    private void Search()
    {
        filteredTransactions = originalTransactions;

        if (SearchText != "")
        {
         filteredTransactions = originalTransactions.Where(x => x.BoardName.Contains(SearchText)).ToArray();
        }
    }

    private void SearchFreeText() //string value
    {
       // FreeText = value;
        filteredTransactions = originalTransactions;

        if (FreeText != "")
        {
         filteredTransactions = originalTransactions.Where(x => x.BoardName.Contains(FreeText)
         )
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
