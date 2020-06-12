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
    public class PetsViewModel:ViewModelBase
    {

        #region Attributes
        private PetModel petSelected;
        private List<PetModel> pets;
        private ObservableCollection<PetModel> petsList;
        #endregion Attributes

        #region Requests
        public RequestPicker<PetModel> petDelete { get; set; }
        public RequestPicker<BaseModel> GetPetsByUser { get; set; }
        #endregion Requests

        #region Commands
        public ICommand PetSelectedCommand { get; set; }
        public ICommand CreatePetViewCommand { get; set; }

        #endregion Commands

        //Constructores
        public PetsViewModel()
        {
            PetSelected = new PetModel();
            Pets = new List<PetModel>();
            PetsList = new ObservableCollection<PetModel>();
            InitializeRequest();
            InitializeCommands();
        }

        #region Getters & Setters
        public PetModel PetSelected
        {
            get { return petSelected; }
            set
            {
                petSelected = value;
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
        private void InitializeCommands()
        {
            PetSelectedCommand = new Command(async () => await GoPetDetail(), () => true);
            CreatePetViewCommand = new Command(async () => await GoToCreatePetView(), () => true);
        }
        private async Task InitializeRequest()
        {
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
        public async Task GoToCreatePetView()
        {
            await NavigationService.PushPage(new CreatePetView());
        }
        public async Task GoPetDetail()
        {
            await NavigationService.PushPage(new PetDetailView(), PetSelected);
        }
        #endregion Methods
    }
}
