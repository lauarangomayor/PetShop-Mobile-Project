using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class StateProductModel: BaseModel
    {
        #region Properties
        private long idStateProduct;
        private string description;
        #endregion

        #region Getters/Setters
        public long IdStateProduct
        {
            get { return idStateProduct; }
            set { idStateProduct = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        #endregion
    }
}
