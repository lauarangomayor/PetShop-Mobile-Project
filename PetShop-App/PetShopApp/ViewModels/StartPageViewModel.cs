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
        #endregion
        #region Initialization
        public StartPageViewModel()
        {
            VetImageTappedCommand = new Command(async () => await VetLogin(), () => true);
        }
        #endregion
        #region Methods
        private async Task VetLogin()
        {
            await NavigationService.PushPage(new LoginView());
        }
        #endregion
    }
}
