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
        private long idPet;
        private string name;
        private long idSpecie;
        private string generalInfo;
        private string birthdate;
        private long idClient;
        private string imagePath;

        #endregion
        #region Getters/Setters
        public long IdPet
        {
            get { return idPet; }
            set { idPet = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public long IdSpecie
        {
            get { return idSpecie; }
            set { idSpecie = value; OnPropertyChanged(); }
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
        public long IdClient
        {
            get { return idClient; }
            set { idClient = value; OnPropertyChanged(); }
        }
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
