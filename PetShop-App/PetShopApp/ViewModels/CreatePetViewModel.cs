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
    public class CreatePetViewModel : ViewModelBase
    {
        #region Properties
        private List<SpecieModel> species;
        private PetModel pet;
        #endregion
        #region Getters/Setters
        public List<SpecieModel> Species
        {
            get { return species; }
            set { species = value; OnPropertyChanged(); }
        }
        public PetModel Pet
        {
            get { return pet; }
            set { pet = value; OnPropertyChanged(); }
        }
        #endregion
        #region Requests
        public RequestPicker<BaseModel> GetSpecies { get; set; }
        public RequestPicker<PetModel> PostPet { get; set; }
        #endregion
        #region Attributes
        public string PetName { get; set; }
        public int PetIndexSpecie { get; set; }
        public string PetGeneralInfo { get; set; }
        public string PetBirthdate { get; set; }
        public long PetOwner { get; set; }
        public string ImagePath { get; set; }
        
        #endregion
        #region Commands
        public ICommand CreatePetCommand { get; set; }
        #endregion
        #region Initialization
        public CreatePetViewModel()
        {
            Species = new List<SpecieModel>();
            InitizalizeRequest();
            InitializeCommands();
        }
        #endregion
        #region Methods
        public async void InitizalizeRequest()
        {
            string urlGetSpecies= EndPoints.SERVER_URL + EndPoints.GET_ALL_SPECIES;
            GetSpecies = new RequestPicker<BaseModel>();
            GetSpecies.StrategyPicker("GET", urlGetSpecies);
            await ListSpecies();

            string urlPostPet = EndPoints.SERVER_URL + EndPoints.CREATE_PET;
            PostPet = new RequestPicker<PetModel>();
            PostPet.StrategyPicker("POST", urlPostPet);
        }
        public void InitializeCommands()
        {
            CreatePetCommand = new Command(async () => await CreatePet(), () => true);
        }

        public async Task ListSpecies()
        {
            APIResponse response = await GetSpecies.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                Species = JsonConvert.DeserializeObject<List<SpecieModel>>(response.Response);
            }
            else
            {
                Exception e;
            }
        }
        public async Task CreatePet()
        {
            try
            {
                PetModel pet = new PetModel()
                {
                    Name = PetName,
                    IdSpecie = Species[PetIndexSpecie].IdSpecie,
                    GeneralInfo = PetGeneralInfo,
                    Birthdate = PetBirthdate,
                    IdClient = Convert.ToInt64(Settings.UId),
                    ImagePath = "C:/Windows/System32/"

                };
                APIResponse response = await PostPet.ExecuteStrategy(pet);
                if (response.IsSuccess)
                {
                    await NavigationService.PopPage();
                }
            }
            catch (Exception e)
            {

            }
        }
        #endregion
    }
}
