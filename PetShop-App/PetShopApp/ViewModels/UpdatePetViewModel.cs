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
    public class UpdatePetViewModel : ViewModelBase
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
        public RequestPicker<PetModel> PutPet { get; set; }
        #endregion
        #region Attributes
        public int PetIndexSpecie { get; set; }
        #endregion
        #region Commands
        public ICommand UpdatePetCommand { get; set; }
        public ICommand UploadImageCommand { get; set; }
        #endregion
        #region Initialization
        public UpdatePetViewModel()
        {
            MemoryStream = new MemoryStream();
            Species = new List<SpecieModel>();
            PetIndexSpecie = -1;
            InitializeCommands();
        }
        public override async Task ConstructorAsync(object parameters = null)
        {
            Pet = parameters as PetModel;
            /*Pet = new PetModel
            {
                IdPet = 10,
                Name = "Eva",
                IdSpecie = 2,
                GeneralInfo = "Una perrita muy juguetona y alegre",
                Birthdate = "2013-05-05T00:41:33",
                IdClient = 2,
                ImagePath = "/9j/4QBwRXhpZgAATU0AKgAAAAgABAEAAAQAAAABAAAC4AEBAAQAAAABAAAFHIdpAAQAAAABAAAAPgESAAMAAAABAAAAAAAAAAAAA6ACAAMAAAABAXAAAKADAAMAAAABAo4AAJIIAAQAAAABAAAAAAAAAAD/4AAQSkZJRgABAQAAAQABAAD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/2wBDAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/wAARCAKOAXADASIAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAr/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFgEBAQEAAAAAAAAAAAAAAAAAAAYH/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8AsoAaQoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH/2Q=="
            };*/
            InitizalizeRequest();
        }
        #endregion
        #region Methods
        public async void InitizalizeRequest()
        {
            string urlGetSpecies = EndPoints.SERVER_URL + EndPoints.GET_ALL_SPECIES;
            GetSpecies = new RequestPicker<BaseModel>();
            GetSpecies.StrategyPicker("GET", urlGetSpecies);
            await ListSpecies();

            string urlPutPet = EndPoints.SERVER_URL + EndPoints.UPDATE_PET + Pet.IdPet.ToString();
            PutPet = new RequestPicker<PetModel>();
            PutPet.StrategyPicker("PUT", urlPutPet);
        }
        public void InitializeCommands()
        {
            UpdatePetCommand = new Command(async () => await UpdatePet(), () => true);
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
        public async Task UpdatePet()
        {
            string base64ToString = "";
            if (memoryStream.ToArray().Length != 0)
            {
                base64ToString = Convert.ToBase64String(memoryStream.ToArray());
            }
            else
            {
                base64ToString = Pet.ImagePath;
            }
            memoryStream = new MemoryStream();
            try
            {
                if (PetIndexSpecie != -1)
                {
                    Pet.IdSpecie = Species[PetIndexSpecie].IdSpecie;
                }
                PetModel pet = new PetModel()
                {
                    IdPet = Pet.IdPet,
                    Name = Pet.Name,
                    IdSpecie = Pet.IdSpecie,
                    GeneralInfo = Pet.GeneralInfo,
                    Birthdate = Pet.Birthdate,
                    IdClient = 2,
                    ImagePath = base64ToString

                };
                APIResponse response = await PutPet.ExecuteStrategy(pet);
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
