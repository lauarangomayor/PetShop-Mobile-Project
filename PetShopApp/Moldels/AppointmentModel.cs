using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    class AppointmentModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private string date;
        public string Description { get; set; }
        private UserVetModel vet;
        public PetModel Pacient { get; set; }
        #endregion

        #region Initialize
        public AppointmentModel(UserVetModel vet)
        {
            if (vet == null)
            {
                throw new System.ArgumentException("AppointmentModel received a null vet argument");
            }
            this.vet = vet;
        }
        #endregion

        #region Getters/Setters
        public string Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(); }
        }
        public UserVetModel Vet
        {
            get { return vet; }
            set { vet = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
