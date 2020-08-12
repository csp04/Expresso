using Expresso.Pages;
using Expresso.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso
{
    public partial class App : Application
    {

        public static string AzureBackendUrl = "https://csp-expresso-api.azurewebsites.net";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<AzureService>();
            
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
