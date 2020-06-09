using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class StateProductModel: BaseModel
    {
        #region Properties
        [JsonProperty("idStateProduct")]
        public long StateProductId { get; set; }
        [JsonProperty("description")]
        public string StateProduct { get; set; }
        #endregion

        #region Getters/Setters

        #endregion
    }
}
