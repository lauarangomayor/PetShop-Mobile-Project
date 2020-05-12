using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    class SpecialtyModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private string name;
        #endregion
        #region Getters/Setters
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
