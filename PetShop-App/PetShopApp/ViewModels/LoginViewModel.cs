using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Attributes
        private LoginShopModel login;
        private string emailEntry;
        private string passwordEntry;
        private bool isClient;
        private bool isVet;
        #endregion
        #region Requests
        public RequestPicker<BaseModel> ValidateLoginClient { get; set; }
        #endregion 
        #region Commands
        public ICommand ShowVetHomeViewCommand { get; set; }
        public ICommand ValidateLoginCommand { get; set; }
        public ICommand CancelLoginCommand { get; set; }
        #endregion
        #region Getters/Setters
        public LoginShopModel Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
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
        public bool IsClient
        {
            get { return isClient; }
            set
            {
                isClient = value; OnPropertyChanged();
            }
        }
        public bool IsVet
        {
            get { return isVet; }
            set
            {
                isVet = value; OnPropertyChanged();
            }
        }
        #endregion
        #region Initizalization
        public LoginViewModel()
        {
            InitiliazeCommands();
        }
        #endregion
        #region Methods
        public void InitiliazeCommands()
        {
            ValidateLoginCommand = new Command(async () => await ValidateLogin(), () => true);
            CancelLoginCommand = new Command(async () => await CancelLogin(), () => true);
            ShowVetHomeViewCommand = new Command(async () => await ShowVetHomeView(), () => true);
        }
        public async Task ShowVetHomeView()
        {
            //await NavigationService.PushPage(new VetHomeView());
        }
        public async Task ValidateLogin()
        {
            string urlGetClientByLogin = EndPoints.SERVER_URL + EndPoints.VALIDATE_CLIENT + EmailEntry + "/" + PasswordEntry;
            ValidateLoginClient = new RequestPicker<BaseModel>();
            ValidateLoginClient.StrategyPicker("GET", urlGetClientByLogin);
            APIResponse response = await ValidateLoginClient.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                Login = JsonConvert.DeserializeObject<LoginShopModel>(response.Response);
                Settings.UId = Login.IdClient.ToString();
                Settings.UEmail = Login.Email;
                await ShowVetHomeView();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El correo no se encuentra en eñ sistema", "OK");
            }
        }
        private async Task CancelLogin()
        {
            await NavigationService.PopPage();

        }
        #endregion
    }
}
