using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using PetShopApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    class PetDetailViewModel : ViewModelBase
    {
        #region Commands
        public ICommand CreateAppointmentCommand { get; set; }
        public ICommand GoToAppointmentsCommand { get; set; }
        public ICommand GoToAppointmentsRecordCommand { get; set; }
        public ICommand DeletePetCommand { get; set; }
        public ICommand GoToUpdatePetViewCommand { get; set; }
        #endregion Commands

        #region Requests
        public RequestPicker<PetModel> petDelete { get; set; }
        #endregion

        #region Properties
        private PetModel petDetail;
        private int quantitySelected;
        #endregion Properties

        #region Getters & Setters
        public PetModel PetDetail
        {
            get { return petDetail; }
            set
            {
                petDetail = value; OnPropertyChanged();
            }
        }

        public int QuantitySelected
        {
            get { return quantitySelected; }
            set
            {
                quantitySelected = value; OnPropertyChanged();
            }
        }

        #endregion
        #region Initialization
        public PetDetailViewModel()
        {
            InitializeCommands();
            InitializationRequest();
        }
        public override async Task ConstructorAsync(object parameters)
        {
            var petDetail = parameters as PetModel;
            PetDetail = petDetail;
        }
        #endregion

        #region Methods
        public void InitializeCommands()
        {
            CreateAppointmentCommand = new Command(async () => await StartCreatingAppointment(), () => true);

            GoToAppointmentsCommand = new Command(async () => await GoToAppointments(), () => true);

            GoToAppointmentsRecordCommand = new Command(async () => await GoToAppointmentsRecord(), () => true);

            GoToUpdatePetViewCommand = new Command(async () => await GoToUpdatePetView(), () => true);

            DeletePetCommand = new Command(async () => await DeletePet(), () => true);

        }
        public async void InitializationRequest()
        {
            string urlDeletePet = EndPoints.SERVER_URL + EndPoints.DELETE_PET;
            petDelete = new RequestPicker<PetModel>();
            petDelete.StrategyPicker("DELETE", urlDeletePet);
        }
        private async Task StartCreatingAppointment()
        {
            /*var promptConfig = new PromptConfig();
            promptConfig.InputType = InputType.Name;
            promptConfig.IsCancellable = true;
            promptConfig.Message = Settings.UEmail +" "+petDetail.Name;
            await UserDialogs.Instance.PromptAsync(promptConfig);*/
            //await Settings.ShoppingCartUser.AddItemToCart(PetDetail);
            //Settings.ShoppingCartUser.ShowItemsFromCart();


            await NavigationService.PushPage(new CreateAppointmentView(), PetDetail);

        }
        private async Task GoToAppointments()
        {
            //await NavigationService.PushPage(new AppointmentsView());

        }
        private async Task GoToAppointmentsRecord()
        {
            await NavigationService.PushPage(new AppointmentRecordView(), PetDetail);

        }
        public async Task GoToUpdatePetView()
        {
            await NavigationService.PushPage(new UpdatePetView(), PetDetail);
        }
        public async Task DeletePet()
        {
            try
            {
                ParametersRequest parameters = new ParametersRequest();
                parameters.Parameters.Add(PetDetail.IdPet.ToString());
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



        #endregion

    }

}
