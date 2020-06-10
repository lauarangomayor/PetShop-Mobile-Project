using Newtonsoft.Json;
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
    public class VetViewModel : UserModel
    {
        #region Attributes
        private UserModel usermodel;
        #endregion Attributes

        #region Requests
        public RequestPicker<UserModel> CreateVet { get; set; }
        #endregion Requests

        #region Commands
        public ICommand RegistrarUsuarioVetCommand { get; set; }
        #endregion Commands

        //Constructores
        public VetViewModel()
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
            string urlRegisterVet = EndPoints.SERVER_URL + EndPoints.REGISTER_VET;

            CreateVet = new RequestPicker<UserModel>();
            CreateVet.StrategyPicker("POST", urlRegisterVet);
        }

        private async Task InitializeCommands()
        {
            RegistrarUsuarioVetCommand = new Command(async () => await SaveVeterinarian());
        }
        #endregion Initialize

        #region Methods
        public async Task SaveVeterinarian()
        {
            ((Command)RegistrarUsuarioVetCommand).ChangeCanExecute();
            await CreateVeterinarian();
        }

        public async Task CreateVeterinarian()
        {
            try
            {
                if (Usermodel.Password != null && Usermodel.Email != null && Usermodel.Name != null &&
                    Usermodel.DocumentId!=null && Usermodel.Address!=null && Usermodel.Telephone != null)
                { 

                    Usermodel.UserType = 0;
                    APIResponse response = await CreateVet.ExecuteStrategy(Usermodel);
                    if (response.IsSuccess)
                    {
                        Console.WriteLine("Guardo");
                    }
                    else
                    {

                    }
                }
                else 
                { 
                    //PopUp de datos incompletos
                }
            }
            catch(Exception e)
            {
                //Error de servidor
            }
        }
        #endregion Methods
    }
}
