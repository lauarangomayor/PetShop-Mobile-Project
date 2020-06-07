using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;

namespace PetShopApp.Moldels
{
    public class PersonModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string DocumentId { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        private string password;

        private string email;

        #endregion
        #region Getters/Setters

        public string Password
        {
            get { return password; }
            set
            {
                password= value;
                OnPropertyChanged(); //Notify to the interface that the passord has changed.
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(); //Notify to the interface that the passord has changed.
            }
        }
        #endregion
    }
}
