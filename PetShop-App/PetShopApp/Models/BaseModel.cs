using Newtonsoft.Json;
using PetShopApp.Services.Propagation;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class BaseModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        [JsonIgnore]
        public long ID { get; set; }
        #endregion Properties
    }
}
