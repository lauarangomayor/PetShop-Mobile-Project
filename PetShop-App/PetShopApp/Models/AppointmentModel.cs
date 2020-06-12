using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Models
{
    public class AppointmentModel : BaseModel
    {
        #region Properties

        private string date;
        public string Description { get; set; }
        public long idPet;

        public long idVeterinarian;

        #endregion

        #region Initialize
        public AppointmentModel()
        {
            /*if (vet == null)
            {
                throw new System.ArgumentException("AppointmentModel received a null vet argument");
            }
            this.vet = vet;*/
        }
        #endregion

        #region Getters/Setters
        public string Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(); }
        }
        public long IdPet
        {
            get { return idPet; }
            set { idPet = value; OnPropertyChanged(); }
        }
        public long IdVeterinarian
        {
            get { return idVeterinarian; }
            set { idVeterinarian = value; OnPropertyChanged(); }
        }
        #endregion
    }

}
