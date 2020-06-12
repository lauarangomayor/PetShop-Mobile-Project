using PetShopApp.Configuration;
using PetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PetShopApp.AuxModels;
using Newtonsoft.Json;
using PetShopApp.Services.APIRest;

namespace PetShopApp.ViewModels
{
    public class AppointmentRecordViewModel : ViewModelBase
    {
        #region Attributes
        private List<AppointmentRecordModel> appointmentsRecords;
        AppointmentRecordModel appointmentRecordModel;
        private PetModel petDetail;
        #endregion Attributes

        #region Requests

        public RequestPicker<BaseModel> GetAppointments { get; set; }
        #endregion Requests

        //Constructores
        public AppointmentRecordViewModel()
        {
            appointmentRecordModel = new AppointmentRecordModel();


        }

        #region Getters & Setters
        public PetModel PetDetail
        {
            get { return petDetail; }
            set
            {
                petDetail = value; OnPropertyChanged();
            }
        }

        public List<AppointmentRecordModel> AppointmentsRecords
        {
            get { return appointmentsRecords; }
            set
            {
                appointmentsRecords = value;
                OnPropertyChanged();
            }
        }

        public override async Task ConstructorAsync(object parameters)
        {
            var petDetail = parameters as PetModel;
            PetDetail = petDetail;
            InitializeRequestAsync();

        }
        #endregion Getters & Setters

        #region Initialize
        public async Task InitializeRequestAsync()
        {
            string urlAppointmentRecords = EndPoints.SERVER_URL + EndPoints.GET_APPOINTMENTRECORDS;

            GetAppointments = new RequestPicker<BaseModel>();
            GetAppointments.StrategyPicker("GET", urlAppointmentRecords);
            AppointmentsRecords = await SelectAppointments();

        }
        #endregion Initialize

        #region Methods
        public async Task<List<AppointmentRecordModel>> SelectAppointments()
        {
            try
            {
                ParametersRequest parameters = new ParametersRequest();
                parameters.Parameters.Add(PetDetail.IdPet.ToString());
                APIResponse response = await GetAppointments.ExecuteStrategy(null, parameters);
                if (response.IsSuccess)
                {
                    return JsonConvert.DeserializeObject<List<AppointmentRecordModel>>(response.Response);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion Methods
    }
}
