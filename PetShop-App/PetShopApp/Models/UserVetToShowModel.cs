using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class UserVetToShowModel : UserModel
    { 
        #region Properties
        private long idVeterinarian;
        private long idUser;
        private UserModel user;
        #endregion

        #region Initialize
        #endregion

        #region Getters/Setters
        public long IdVeterinarian
        {
            get { return idVeterinarian; }
            set
            {
                idVeterinarian = value;
                OnPropertyChanged();
            }
        }
        public long IdUser
        {
            get { return idUser; }
            set
            {
                idUser = value;
                OnPropertyChanged();
            }
        }

        public UserModel User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
