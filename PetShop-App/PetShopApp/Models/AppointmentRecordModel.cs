using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class AppointmentRecordModel : BaseModel
    {
        #region Properties
        [JsonProperty("idAppointmentRecord")]
        private int idRecord;

        [JsonProperty("idAppointment")]
        private int idAppointment;

        [JsonProperty("appointmentDate")]
        private string appointmentDate;

        [JsonProperty("idVet")]
        private int idvet;

        [JsonProperty("idPet")]
        private int idPet;

        [JsonProperty("abstractAppointment")]
        private string abstractAppointment;
        #endregion

        #region Getters/Setters
        public string AbstractAppointment
        {
            get { return abstractAppointment; }
            set { abstractAppointment = value; OnPropertyChanged(); }
        }


        public int IdPet
        {
            get { return idPet; }
            set { idPet = value; OnPropertyChanged(); }
        }


        public int Idvet
        {
            get { return idvet; }
            set { idvet = value; OnPropertyChanged(); }
        }


        public string AppointmentDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; OnPropertyChanged(); }
        }

        public int IdAppointment
        {
            get { return idAppointment; }
            set { idAppointment = value; OnPropertyChanged(); }
        }

        public int IdRecord
        {
            get { return idRecord; }
            set { idRecord = value; OnPropertyChanged(); }
        }
        #endregion

    }
}
