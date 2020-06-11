using Acr.UserDialogs;
using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
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
        #region Attributes
        private LoginClientModel login;
        private string emailEntry;
        private string passwordEntry;
        #endregion

        #region Requests
        public RequestPicker<BaseModel> ValidateLoginClient { get; set; }
        #endregion Requests

        public string EmailEntry
        {
            get { return emailEntry; }
            set
            {
                emailEntry = value; OnPropertyChanged();
            }
        }

        public string PasswordEntry
        {
            get { return passwordEntry; }
            set
            {
                passwordEntry = value; OnPropertyChanged();
            }
        }

        #region Getters & Setters
        public LoginClientModel Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters

        #region Commands
        public ICommand ValidateLoginCommand { get; set; }
        public ICommand CancelLoginCommand { get; set; }
        
        #endregion

        #region Initialization
        public LoginShopViewModel()
        {
            ValidateLoginCommand = new Command(async () =>  InitizalizeRequest(), () => true);
            CancelLoginCommand = new Command(async () => await CancelLogin(), () => true);
        }
        #endregion

        public async void InitizalizeRequest()
        {
            string urlGetClientByLogin = EndPoints.SERVER_URL + EndPoints.VALIDATE_USER + EmailEntry +"/" + PasswordEntry + "/1";
            ValidateLoginClient = new RequestPicker<BaseModel>();
            ValidateLoginClient.StrategyPicker("GET", urlGetClientByLogin);
            await ValidateLogin();
        }


        #region Methods
        private async Task ValidateLogin()
        {
            //Settings.UEmail = emailEntry;
            APIResponse response = await ValidateLoginClient.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                Login = JsonConvert.DeserializeObject<LoginClientModel>(response.Response);
                Settings.UId = Login.IdClient.ToString();
                Settings.UEmail = Login.Email;
                await PopupNavigation.PopAsync();
            }
            else
            {
                //Exception e;
                //UserDialogs.Instance.ShowError("El usuario no existe en el sistema", 4000);
                //await Application.Current.MainPage.DisplayAlert("Error", "El usuario no existe en el sistema", "OK");
                await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña invalidos", "OK");
            };
            
        } 
            
        private async Task CancelLogin()
        {
             await PopupNavigation.PopAsync();

        }


        #endregion
    }
}
