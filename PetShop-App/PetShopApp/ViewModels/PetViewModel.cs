using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using PetShopApp.Services.Navigation;
using PetShopApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class PetViewModel:ViewModelBase
    {

        #region Attributes
        private PetModel petmodel;
        private List<PetModel> pets;
        private ObservableCollection<PetModel> petsList;
        private PetModel petSelected;
        private string idPet = "2";
        #endregion Attributes

        #region Requests
        public RequestPicker<PetModel> petDelete { get; set; }
        public RequestPicker<BaseModel> GetPetsByUser { get; set; }
        #endregion Requests

        #region Commands
        public ICommand DeletePetCommand { get; set; }
        public ICommand PetSelectedCommand { get; set; }
        #endregion Commands

        //Constructores
        public PetViewModel()
        {
            Petmodel = new PetModel();
            Pets = new List<PetModel>();
            PetsList = new ObservableCollection<PetModel>();
            InitializeRequest();
            InitializeCommands();
        }

        #region Getters & Setters
        public PetModel Petmodel
        {
            get { return petmodel; }
            set
            {
                petmodel = value;
                OnPropertyChanged();
            }
        }

        public List<PetModel> Pets
        {
            get { return pets; }
            set
            {
                pets = value;
                OnPropertyChanged();
            }
        }

        public PetModel PetSelected
        {
            get { return petSelected; }
            set { petSelected = value; OnPropertyChanged(); }
        }
        public ObservableCollection<PetModel> PetsList
        {
            get { return petsList; }
            set
            {
                petsList = value;
                OnPropertyChanged();
            }
        }

        #endregion Getters & Setters

        #region Initialize
        private async Task InitializeCommands()
        {
            DeletePetCommand = new Command(async () => await DeletePet(), () => true);
            PetSelectedCommand = new Command(async () => await GoPetDetail(), () => true);
        }
        private async Task InitializeRequest()
        {
            //string urlDeletePet = EndPoints.SERVER_URL+ EndPoints.DELETE_PET;

            string urlDeletePet = EndPoints.SERVER_URL + EndPoints.DELETE_PET; 
            petDelete = new RequestPicker<PetModel>();
            petDelete.StrategyPicker("DELETE", urlDeletePet);

            string urlGetPetsByClientId = EndPoints.SERVER_URL + EndPoints.GET_PETS_BY_CLIENT + Settings.UId;
            GetPetsByUser = new RequestPicker<BaseModel>();
            GetPetsByUser.StrategyPicker("GET", urlGetPetsByClientId);
            await ListPets();
        }


        #endregion Initialize

        #region Methods
        public async Task ListPets()
        {
            APIResponse response = await GetPetsByUser.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Pets = JsonConvert.DeserializeObject<List<PetModel>>(response.Response, jsonSerializerSettings);
                foreach (var p in Pets)
                {
                    PetsList.Add(p);
                }

            }
            else
            {
                Exception e;
            }

        }
        public async Task DeletePet()
        {
            try
            {
                ParametersRequest parameters = new ParametersRequest();
                parameters.Parameters.Add(idPet);
                APIResponse response = await petDelete.ExecuteStrategy(null, parameters);
                if (response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert("Opreción exitosa", "La mascota ha sido eliminada", "OK");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "La mascota no ha sido eliminada", "OK");

                }

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio una excepción", "OK");

            }

        }

        public async Task GoPetDetail()
        {
            await NavigationService.PushPage(new PetDetailView(), PetSelected);
        }

        #endregion Methods
    }
}
