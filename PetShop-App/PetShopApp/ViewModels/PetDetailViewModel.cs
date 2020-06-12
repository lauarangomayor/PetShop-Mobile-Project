using PetShopApp.Helpers;
using PetShopApp.Models;
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
        #endregion Commands

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
            CreateAppointmentCommand = new Command(async () => await StartCreatingAppointment(), () => true);

            GoToAppointmentsCommand = new Command(async () => await GoToAppointments(), () => true);

            GoToAppointmentsRecordCommand = new Command(async () => await GoToAppointmentsRecord(), () => true);
        }
        public override async Task ConstructorAsync(object parameters)
        {


            var petDetail = parameters as PetModel;
            PetDetail = petDetail;
        }
        #endregion

        #region Methods
        private async Task StartCreatingAppointment()
        {


                /*var promptConfig = new PromptConfig();
                promptConfig.InputType = InputType.Name;
                promptConfig.IsCancellable = true;
                promptConfig.Message = Settings.UEmail +" "+petDetail.Name;
                await UserDialogs.Instance.PromptAsync(promptConfig);*/
                //await Settings.ShoppingCartUser.AddItemToCart(PetDetail);
                //Settings.ShoppingCartUser.ShowItemsFromCart();

            //NavigationService.PushPage(new CategoriesView());
        }
        private async Task GoToAppointments()
        {
            //await NavigationService.PushPage(new AppointmentsView());

        }
        private async Task GoToAppointmentsRecord()
        {
            //await NavigationService.PushPage(new AppointmentsView());

        }



        #endregion

    }

}
