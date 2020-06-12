using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
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
        private ImageSource image;
        private MemoryStream memoryStream;
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
        public ImageSource Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); }
        }
        public MemoryStream MemoryStream
        {
            get { return memoryStream; }
            set { memoryStream = value; OnPropertyChanged(); }
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
        public ICommand UploadImageCommand { get; set; }
        #endregion
        #region Initialization
        public CreatePetViewModel()
        {
            MemoryStream = new MemoryStream();
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
            UploadImageCommand = new Command(async () => await UploadImage(), () => true);
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
        public async Task UploadImage()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
            });
            if (file == null)
            {
                return;
            }
            Image = ImageSource.FromStream(() =>
            {
                Stream stream = file.GetStream();
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                return stream;
            });
        }
        public async Task CreatePet()
        {
            try
            {
                string base64ToString = Convert.ToBase64String(memoryStream.ToArray());
                memoryStream = new MemoryStream();
                PetModel pet = new PetModel()
                {
                    Name = PetName,
                    IdSpecie = Species[PetIndexSpecie].IdSpecie,
                    GeneralInfo = PetGeneralInfo,
                    Birthdate = PetBirthdate,
                    IdClient = Convert.ToInt64(Settings.UId),
                    ImagePath = base64ToString

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
