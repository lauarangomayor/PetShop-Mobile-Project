using PetShopApp.Services.APIRest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class LoginClientModel: BaseModel
    {
        #region Properties
        private int idClient;


        private string email;

        private string password;

        #endregion

        public int IdClient
        {
            get { return idClient; }
            set { idClient = value; OnPropertyChanged(); }
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
