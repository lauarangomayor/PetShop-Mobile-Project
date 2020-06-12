using PetShopApp.Helpers;
using PetShopApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        #region Commands
        public ICommand VetImageTappedCommand { get; set; }
        public ICommand ShopImageTappedCommand { get; set; }
        #endregion
        #region Initialization
        public StartPageViewModel()
        {
            VetImageTappedCommand = new Command(async () => await VetLogin(), () => true);
            ShopImageTappedCommand = new Command(async () => await ShopLogin(), () => true);
        }
        #endregion
        #region Methods
        private async Task VetLogin()
        {
            if (Settings.UEmail == "")
            {
                await NavigationService.PushPage(new LoginView());
            }
            else
            {
                await NavigationService.PushPage(new PetsTabbedPageView());
            }
        }

        private async Task ShopLogin()
        {
            await NavigationService.PushPage(new ShopTabbedPageView());
        }
        #endregion
    }
}
