using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        #region Attributes
        private UserModel usermodel;
        private LoginClientModel login;

        #endregion Attribute

        #region Requests
        public RequestPicker<UserModel> clientCreate { get; set; }
        #endregion Requests

        #region Commands
        public ICommand RegistrarUsuarioClientCommand { get; set; }
        #endregion Commands

        //Constructores
        public ClientViewModel()
        {
            Usermodel = new UserModel();
            InitializeRequestAsync();
            InitializeCommands();
        }

        #region Getters & Setters
        public UserModel Usermodel
        {
            get { return usermodel; }
            set
            {
                usermodel = value;
                OnPropertyChanged();
            }
        }

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

        #region Initialize
        private async Task InitializeRequestAsync()
        {
            string urlRegisterClient = EndPoints.SERVER_URL + EndPoints.REGISTER_CLIENT;

            clientCreate = new RequestPicker<UserModel>();
            clientCreate.StrategyPicker("POST", urlRegisterClient);
        }

        private async Task InitializeCommands()
        {
            RegistrarUsuarioClientCommand = new Command(async () => await SaveClient());
        }
        #endregion Initialize

        #region Methods
        public async Task SaveClient()
        {
            ((Command)RegistrarUsuarioClientCommand).ChangeCanExecute();
            await CreateClient();
        }

 
        public async Task CreateClient()
        {
            try
            {
                if (Usermodel.Password != null && Usermodel.Email!=null && Usermodel.Name!=null ) 
                { 

                    Usermodel.UserType = 1;
                    APIResponse response = await clientCreate.ExecuteStrategy(Usermodel);
                    if (response.IsSuccess)
                    {
                        Login = JsonConvert.DeserializeObject<LoginClientModel>(response.Response);
                        Settings.UId = Login.IdClient.ToString();
                        Settings.UEmail = Login.Email.ToString(); 
                        await Application.Current.MainPage.DisplayAlert("Guardado", "Se registro satisfactoriamente", "OK");

                        Usermodel.DocumentId = null; //Limpiar campos
                        Usermodel.Name = null;
                        Usermodel.Telephone = null;
                        Usermodel.Address = null;
                        Usermodel.Email = null;
                        Usermodel.Password = null;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "El registro no fue exitoso", "OK");

                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Complete todos los campos", "OK");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Se presento una exepción", "OK");

            }

        }
     
        #endregion Methods

    }
}
