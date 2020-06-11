using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Models
{
    public class UserModel : BaseModel
    {
        #region Properties

        private string documentId;

        private string name;

        private string telephone;

        private string address;

        private int userType;

        private string password;

        private string email;

        #endregion


        #region Getters/Setters
        public string DocumentId
        {
            get { return documentId; }
            set
            {
                documentId = value;
                OnPropertyChanged(); //Notify to the interface that the documentId has changed.
            }
        }

        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                OnPropertyChanged(); //Notify to the interface that the telephone has changed.
            }
        }



        public string Name
        {
            get { return name;}
            set
            {
                name = value;
                OnPropertyChanged(); //Notify to the interface that the name has changed.
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(); //Notify to the interface that the address has changed.
            }
        }

        public int UserType
        {
            get { return userType; }
            set
            {
                userType = value;
                OnPropertyChanged(); //Notify to the interface that the userType has changed.
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(); //Notify to the interface that the passord has changed.
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(); //Notify to the interface that the email has changed.
            }
        }
        #endregion
    }
}
