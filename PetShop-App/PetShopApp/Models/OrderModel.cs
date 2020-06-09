using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Models
{
    public class OrderModel : BaseModel
    {
        #region Properties
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
