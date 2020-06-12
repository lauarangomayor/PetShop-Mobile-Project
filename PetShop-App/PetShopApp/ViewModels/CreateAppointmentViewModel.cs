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
        private string selectedHour;
        private List<UserVetModel> veterinarians;
        private ObservableCollection<UserVetModel> vetsList;
        #endregion
        #region Getters/Setters
        public string SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(); }
        }
        public string SelectedHour
        {
            get { return selectedHour; }
            set { selectedHour = value; OnPropertyChanged(); }
        }
        public List<UserVetModel> Veterinarians
        {
            get { return veterinarians; }
            set { veterinarians = value; OnPropertyChanged(); }
        }
        public ObservableCollection<UserVetModel> VetsList
        {
            get { return vetsList; }
            set { vetsList = value; OnPropertyChanged(); }
        }
        #endregion
        #region Commands
        public ICommand SearchVetsCommand { get; set; }
        #endregion
        #region Requests
        public RequestPicker<BaseModel> Getvets { get; set; }
        #endregion
        #region Initialization
        public CreateAppointmentViewModel()
        {
            InitializeCommands();
        }
        #endregion
        #region Methods
        public void InitializeCommands()
        {
            SearchVetsCommand = new Command(async () => await SearchVets(), () => true);
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
                Veterinarians = JsonConvert.DeserializeObject<List<UserVetModel>>(response.Response, jsonSerializerSettings);
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

        #endregion

    }
}
