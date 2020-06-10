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
        private long idCategory;
        private string name;
        #endregion

        #region Getters/Setters
        public long IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        #endregion
    }
}
