using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    class PersonModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        private string password;

        private int email;

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
        #endregion
    }
}
