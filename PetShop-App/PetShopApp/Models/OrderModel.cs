using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    public class OrderModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private int state;
        #endregion
        #region Getters/Setters
        public int State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
