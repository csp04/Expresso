using Expresso.Services;
using ExpressoApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PropertyChanged;

namespace Expresso.ViewModels
{

    public class MenuPageViewModel : BaseViewModel
    {
        private IDataService service = DependencyService.Get<IDataService>();

        public ObservableCollection<ExpressoApi.Models.Menu> Menus { get; set; }

        public bool NoLoadedMenus { get; set; } = false;

        public MenuPageViewModel()
        {
            _ = GetMenus();
        }

        private async Task GetMenus()
        {
            IsBusy = true;
            if(!DesignMode.IsDesignModeEnabled)
            {
                try
                {
                    Menus = new ObservableCollection<ExpressoApi.Models.Menu>(await service.GetMenus());
                }
                catch
                {
                    NoLoadedMenus = true;
                }
                
            }
            IsBusy = false;
        }
    }

    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel
    {
        public bool IsBusy { get; set; } = false;
    }
}
