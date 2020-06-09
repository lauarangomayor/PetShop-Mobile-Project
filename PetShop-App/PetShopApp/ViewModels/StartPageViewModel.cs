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
        public ICommand ShopImageTappedCommad { get; set; }
        #endregion
        #region Initialization
        public StartPageViewModel()
        {
            VetImageTappedCommand = new Command(async () => await VetLogin(), () => true);
            ShopImageTappedCommad = new Command(async () => await ShopHome(), () => true);
        }
        #endregion
        #region Methods
        private async Task VetLogin()
        {
            await NavigationService.PushPage(new LoginView());
        }

        private async Task ShopHome()
        {
            await NavigationService.PushPage(new ShopTabbedPage());
        }
        #endregion
    }
}
