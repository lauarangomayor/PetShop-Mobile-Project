using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PetShopApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;

namespace PetShopApp.Moldels
{
    public class CategoryModel : BaseModel
    {
        #region Properties
        [JsonProperty("categoryid")]
        public long CategoryId { get; set; }
        [JsonProperty("categoryname")]
        public string Name { get; set; }
        #endregion

        #region Getters/Setters
        
        #endregion
    }
}
