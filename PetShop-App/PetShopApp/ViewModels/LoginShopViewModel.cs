using PetShopApp.Helpers;
using PetShopApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    class LoginShopViewModel : ViewModelBase
    {
        #region Properties
        private string emailEntry;
        #endregion
        public string EmailEntry
        {
            get { return emailEntry; }
            set
            {
                emailEntry = value; OnPropertyChanged();
            }
        }
        #region Commands
        public ICommand ValidateLoginCommand { get; set; }
        public ICommand CancelLoginCommand { get; set; }
        
        #endregion
        #region Initialization
        public LoginShopViewModel()
        {
            ValidateLoginCommand = new Command(async () => await ValidateLogin(), () => true);
            CancelLoginCommand = new Command(async () => await CancelLogin(), () => true);
        }
        #endregion
        #region Methods
        private async Task ValidateLogin()
        {
            //Settings.UEmail = emailEntry;
            if (EmailEntry != null)
            {
                Settings.UId = "1";
                Settings.UEmail = EmailEntry;
                await PopupNavigation.PopAsync();
            } 
            
        }

        private async Task CancelLogin()
        {
             await PopupNavigation.PopAsync();

        }


        #endregion
    }
}
