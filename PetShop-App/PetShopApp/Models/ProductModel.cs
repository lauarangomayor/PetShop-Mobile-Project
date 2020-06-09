using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Models
{
    public class ProductModel : BaseModel
    {
        #region Properties
        private string name;
        private string description;
        private float unitPrice;
        private CategoryModel category;
        private int stock;
        private string image;
        private StateProductModel stateProduct;
        #endregion
        #region Initialize
        /*
        public ProductModel(CategoryModel category, int stock, StateProductModel stateProduct)
        {
            if (category == null | stock < 0 | stateProduct == null)
            {
                throw new System.ArgumentException("ProductModel received a null category or an invalid stock argument");
            }
            this.category = category;
            this.stock = stock;
        }*/

        #endregion
        #region Getters/Setters
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }
        public float UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; OnPropertyChanged(); }
        }
        
        public CategoryModel Category
        {
            get { return category; }
            set {category = value; OnPropertyChanged();}
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; OnPropertyChanged(); }
        }

        public string Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); }
        }

        public StateProductModel StateProduct
        {
            get { return stateProduct; }
            set { stateProduct = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
