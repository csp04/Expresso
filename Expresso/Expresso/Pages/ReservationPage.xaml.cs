using Expresso.Models;
using Expresso.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();

            var vm = BindingContext as ReservationPageViewModel;

            vm.SaveExecuted += Vm_SaveExecuted;
        }

        private void Vm_SaveExecuted(object sender, bool e)
        {
            if(e)
            {
                DisplayAlert("Alright!", "Your table has been reserved!", "OK");
                (BindingContext as ReservationPageViewModel).Reservation = new ReservationModel();
            }
            else
            {
                DisplayAlert("Oops!", "Something went wrong. Please try again.", "OK");
            }
        }
    }
}