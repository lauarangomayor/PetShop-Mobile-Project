using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PetShopApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;

namespace PetShopApp.Models
{
    public class CategoryModel : BaseModel
    {
        #region Properties
        // crear idcategory
        public long IdCategory { get; set; }
        public string Name { get; set; }
        #endregion

        #region Getters/Setters
        
        #endregion
    }
}
