using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RapidNRIMs.Model.Logo;
using RapidNRIMs.Services;
using static System.Net.WebRequestMethods;

namespace RapidNRIMs.Pages.ComponentBased.LogoBased
{
    public class LogoBase : ComponentBase
    {

        protected string logoEPR { get; set; } = string.Empty;
        protected string logoR { get; set; } = string.Empty;


        [Inject]
        protected AppData AppData { get; set; }
        [Inject]
        protected IConfiguration connect { get; set; }
        [Inject]
        protected IToastService ToastService { get; set; }
        [Inject]
        protected HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                AppData.imageLogos = await Http.GetFromJsonAsync<List<ImageLogo>>($"{connect["nurl"]}/api/GetFileLogo");

                var resultLogoE = AppData.imageLogos.Find(x => x.Id == 1);
                if (resultLogoE != null)
                {
                    logoEPR = resultLogoE.ImageName;
                }


                var resultLogoR = AppData.imageLogos.Find(x => x.Id == 2);
                if (resultLogoR != null)
                {
                    logoR = resultLogoR.ImageName;
                }
            }
            catch (Exception e)
            {
                ToastService.ShowError($"Error {e.Message}");
            }

        }   


    }
}
