using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Moldels
{
    public class AppointmentModel : BaseModel
    {
        #region Properties
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
