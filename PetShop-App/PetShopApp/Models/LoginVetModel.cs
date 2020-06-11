using PetShopApp.Services.APIRest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class LoginVetModel: BaseModel
    {
        #region Properties
        private int idVeterinarian;


        private string email;

        private string password;

        #endregion

        public int IdVeterinarian
        {
            get { return idVeterinarian; }
            set { idVeterinarian = value; OnPropertyChanged(); }
        }


        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }


        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }
    }
}
