using PetShopApp.AuxModels;
using PetShopApp.Configuration;
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
    public class ClientViewModel : ViewModelBase
    {
        #region Attributes
        private UserModel usermodel;
        #endregion Attributes

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
                if (usermodel.Password != null && usermodel.Email!=null && usermodel.Name!=null ) 
                { 

                    Usermodel.UserType = 1;
                    APIResponse response = await clientCreate.ExecuteStrategy(usermodel);
                    if (response.IsSuccess)
                    {
                        Console.WriteLine("Guardo");
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception e)
            {

            }
        
    }
     
        #endregion Methods

    }
}
