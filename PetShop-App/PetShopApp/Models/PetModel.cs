using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Models
{
    public class PetModel : BaseModel
    {
        #region Properties 
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private string name;
        private string specie;
        private string birthdate;
        private string generalInfo;
        public UserClientModel Owner { get; set; }
                
        #endregion
        #region Getters/Setters
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public string Specie
        {
            get { return specie; }
            set { specie = value; OnPropertyChanged(); }
        }
        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; OnPropertyChanged(); }
        }

        public string GeneralInfo
        {
            get { return generalInfo; }
            set { generalInfo = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
