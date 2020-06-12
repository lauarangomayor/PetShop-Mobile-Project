using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    class ShoppingCartShowModel : BaseModel
    {
        #region Attributes
        private long idProduct;
        private string name;
        private string imagePath;
        private int quantitySelected;
        private float unitPrice;
        private string unitPriceString;
        #endregion

        public ShoppingCartShowModel()
        {

        }


        #region Getters & Setters
        public long IdProduct
        {
            get { return idProduct; }
            set { idProduct = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public float UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; OnPropertyChanged(); }
        }

        public string UnitPriceString
        {
            get { return unitPriceString; }
            set { unitPriceString = value; OnPropertyChanged(); }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }

        public int QuantitySelected
        {
            get { return quantitySelected; }
            set { quantitySelected = value; OnPropertyChanged(); }
        }


        #endregion
    }
}
