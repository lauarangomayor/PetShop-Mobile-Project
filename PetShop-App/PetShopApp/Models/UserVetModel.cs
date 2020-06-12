using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Models
{
    public class UserVetModel : UserModel
    {
        #region Properties
        private long idVeterinarian;
        private long idUser;
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
        #endregion
    }
}
