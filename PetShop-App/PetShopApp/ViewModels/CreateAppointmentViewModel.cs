using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class CreateAppointmentViewModel: ViewModelBase
    {
        #region Properties
        private string selectedDate;
        private List<UserVetToShowModel> vetsU;
        private string selectedHour;
        private List<UserVetToShowModel> veterinarians;
        private ObservableCollection<UserVetToShowModel> vetsList;
        private PetModel petSelected;
        public int SelectedVetIndex { get; set; }

        #endregion

        #region Requests
        public RequestPicker<AppointmentModel> PostAppointment { get; set; }
        #endregion
        #region Getters/Setters
        public string SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(); }
        }
        public List<UserVetToShowModel> VetsU
        {
            get { return vetsU; }
            set { vetsU = value; OnPropertyChanged(); }
        }
        public string SelectedHour
        {
            get { return selectedHour; }
            set { selectedHour = value; OnPropertyChanged(); }
        }
        public List<UserVetToShowModel> Veterinarians
        {
            get { return veterinarians; }
            set { veterinarians = value; OnPropertyChanged(); }
        }
        public ObservableCollection<UserVetToShowModel> VetsList
        {
            get { return vetsList; }
            set { vetsList = value; OnPropertyChanged(); }
        }

        public PetModel PetSelected
        {
            get { return petSelected; }
            set { petSelected = value; OnPropertyChanged(); }
        }


        #endregion
        #region Commands
        public ICommand SearchVetsCommand { get; set; }

        public ICommand CreateAppointmentCommand { get; set; }
        #endregion
        #region Requests
        public RequestPicker<BaseModel> Getvets { get; set; }
        #endregion
        #region Initialization
        public CreateAppointmentViewModel()
        {
            VetsList = new ObservableCollection<UserVetToShowModel>();
            Veterinarians = new List<UserVetToShowModel>();
            InitizalizeRequest();
            InitializeCommands();
        }
        public override async Task ConstructorAsync(object parameters)
        {
            var petSelected = parameters as PetModel;
            PetSelected = petSelected;
        }
        #endregion
        #region Methods
        public async void InitizalizeRequest()
        {

            string urlPostAppointment = EndPoints.SERVER_URL + EndPoints.CREATE_APPOINTMENT;
            PostAppointment = new RequestPicker<AppointmentModel>();
            PostAppointment.StrategyPicker("POST", urlPostAppointment);
        }
        public void InitializeCommands()
        {
            SearchVetsCommand = new Command(async () => await SearchVets(), () => true);
            CreateAppointmentCommand = new Command(async () => await CreateApointment(), () => true);
        }

        public async Task SearchVets()
        {
            string date = SelectedDate.Substring(0, 10);
            string day = date[0].ToString()+date[1];
            string dateUrlParse = date[0].ToString() + date[1].ToString() +"-" +date[3].ToString() + date[4].ToString() + "-"+date[8].ToString() + date[9].ToString();
            string urlGetAvailableVets = EndPoints.SERVER_URL + EndPoints.GET_AVAILABLE_VETS + dateUrlParse + "&" + selectedHour;
            Getvets = new RequestPicker<BaseModel>();
            Getvets.StrategyPicker("GET", urlGetAvailableVets);
            APIResponse response = await Getvets.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Veterinarians = JsonConvert.DeserializeObject<List<UserVetToShowModel>>(response.Response, jsonSerializerSettings);
                foreach (var v in Veterinarians)
                {
                    VetsList.Add(v);
                }

            }
            else
            {
                Exception e;
            }

        }
        public async Task CreateApointment()
        {
            try
            {
                
                AppointmentModel appointment = new AppointmentModel ()
                {
                    Date = SelectedDate,
                    Description = "",
                    IdPet = PetSelected.IdPet,
                    IdVeterinarian = VetsList[SelectedVetIndex].IdVeterinarian,

                };
                APIResponse response = await PostAppointment.ExecuteStrategy(appointment);
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
