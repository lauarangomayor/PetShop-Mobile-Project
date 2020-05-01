using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    class UserVetModel : PersonModel
    {
        #region Properties
        private List<AppointmentModel> appointments;
        private List<SpecialtyModel> specialties;
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
