using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Moldels
{
    class UserVetModel : PersonModel
    {
        #region Properties
        private List<AppointmentModel> appointments;
        private List<SpecialtyModel> specialties;
        #endregion

        #region Initialize

    public UserVetModel(List<SpecialtyModel> specialties)
        {
            if (!specialties.Any())
            {
                throw new System.ArgumentException("UserVetModel received an empty List<SpecialtyModel> argument");
            }
            this.specialties = new List<SpecialtyModel>();
            this.specialties = specialties;
            
        }
        #endregion

        #region Getters/Setters
        public List<AppointmentModel> Appointments
        {
            get { return appointments; }
            set
            {
                appointments = value;
                OnPropertyChanged();
            }
        }
        public List<SpecialtyModel> Specialties
        {
            get { return specialties; }
            set
            {
                specialties = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
