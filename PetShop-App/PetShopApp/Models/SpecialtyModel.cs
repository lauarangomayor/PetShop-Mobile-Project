using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Models
{
    public class SpecialtyModel : BaseModel
    {
        #region Properties
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
