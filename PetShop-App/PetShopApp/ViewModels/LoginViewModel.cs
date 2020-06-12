using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using PetShopApp.Views;
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
        private LoginClientModel loginClient;
        private LoginVetModel loginVet;
        private string emailEntry;
        private string passwordEntry;
        private bool isClient;
        private bool isVet;
        #endregion
        #region Requests
        public RequestPicker<BaseModel> ValidateLoginUser { get; set; }
        #endregion 
        #region Commands
        public ICommand ShowVetHomeViewCommand { get; set; }
        public ICommand ValidateLoginCommand { get; set; }
        public ICommand CancelLoginCommand { get; set; }
        #endregion
        #region Getters/Setters
        public LoginClientModel LoginClient
        {
            get { return loginClient; }
            set
            {
                loginClient = value;
                OnPropertyChanged();
            }
        }
        public LoginVetModel LoginVet
        {
            get { return loginVet; }
            set
            {
                loginVet = value;
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
            string userType = "";
            if (IsVet)
            {
                 userType = "0";
            }
            else if (IsClient)
            {
                userType = "1";
            }
            string urlGetUserByLogin = EndPoints.SERVER_URL + EndPoints.VALIDATE_USER + EmailEntry + "/" + PasswordEntry + "/" + userType ;
            ValidateLoginUser = new RequestPicker<BaseModel>();
            ValidateLoginUser.StrategyPicker("GET", urlGetUserByLogin);
            APIResponse response = await ValidateLoginUser.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                
                if (userType == "1")
                {
                    LoginClient = JsonConvert.DeserializeObject<LoginClientModel>(response.Response);
                    Settings.UId = LoginClient.IdClient.ToString();
                    Settings.UEmail = LoginClient.Email;
                    NavigationService.PopPage();
                    NavigationService.PushPage(new PetsTabbedPageView());
                    
                }
                else
                {
                    LoginVet = JsonConvert.DeserializeObject<LoginVetModel>(response.Response);
                    Settings.UId = LoginVet.IdVeterinarian.ToString();
                    Settings.UEmail = LoginVet.Email;
                    await Application.Current.MainPage.DisplayAlert("Alert", "Sección de Veterinarios en Construcción", "OK");
                }
                
               
                await ShowVetHomeView();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña invalidos", "OK");
            }
        }
        private async Task CancelLogin()
        {
            await NavigationService.PopPage();

        }
        #endregion
    }
}
