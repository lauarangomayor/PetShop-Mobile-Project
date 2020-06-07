using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;

namespace PetShopApp.Moldels
{
    public class CategoryModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        [JsonIgnore]
        public int ID { get; set; }
        [JsonProperty("categoryid")]
        public long CategoryId { get; set; }
        [JsonProperty("categoryname")]
        public string Name; 
        #endregion
        #region Getters/Setters
      
        #endregion
    }
}
