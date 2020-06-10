using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class StateProductModel: BaseModel
    {
        #region Properties
        public long IdStateProduct { get; set; }
        public string Description { get; set; }
        #endregion

        #region Getters/Setters

        #endregion
    }
}
