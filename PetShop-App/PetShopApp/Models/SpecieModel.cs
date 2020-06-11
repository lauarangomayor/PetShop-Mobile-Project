using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    public class SpecieModel : BaseModel
    {
        #region Properties
        private long idSpecie;
        private string specie;
        #endregion
        #region Getters/Setters
        public long IdSpecie
        {
            get { return idSpecie; }
            set { idSpecie = value; OnPropertyChanged(); }
        }
        public string Specie
        {
            get { return specie; }
            set { specie = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
