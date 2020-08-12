using Expresso.Helpers;
using Expresso.Models;
using Expresso.Services;
using ExpressoApi.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Expresso.ViewModels
{
    class ReservationPageViewModel : BaseViewModel
    {

        public event EventHandler<bool> SaveExecuted;

        private IDataService service = DependencyService.Get<IDataService>();

        public ReservationModel Reservation { get; set; } = new ReservationModel();

        public IAsyncCommand SaveCommand { get; }

        public ReservationPageViewModel()
        {
            SaveCommand = new AsyncCommand(() => OnSave());
        }

        private async Task OnSave()
        {
            var executing = SaveCommand.IsExecuting;
            var saved = true;
            try
            {
                var r = new Reservation
                {
                    Name = Reservation.Name,
                    Email = Reservation.Email,
                    Phone = Reservation.Phone,
                    TotalPeople = int.Parse(Reservation.TotalPeople),
                    Date = Reservation.Date,
                    Time = Reservation.Time.ToString()
                };
                await Task.Delay(2500);
                await service.ReserveTable(r);
            }
            catch
            {
                saved = false;
            }
            finally
            {
                SaveExecuted?.Invoke(this, saved);
            }
        }
        
    }
}
