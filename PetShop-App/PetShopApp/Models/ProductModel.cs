using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;
using Newtonsoft.Json;

namespace PetShopApp.Models
{
    public class ProductModel : BaseModel
    {
        #region Properties
        private long idProduct;
        private string name;
        private string description;
        private long idCategory;
        /*[JsonIgnore]
        private CategoryModel category;*/
        private int quantityAvailable;
        private float unitPrice;
        private string unitPriceString;
        private long idStateProduct;
        /*[JsonIgnore]
        private StateProductModel stateProduct;*/
        private string imagePath;
        
        #endregion
        #region Initialize
        public ProductModel()
        {
            /*if (quantityAvailable < 0)
            {
                throw new System.ArgumentException("Se recibió algún argumento nulo en productmodel");
            }
            this.category = category;
            this.stock = stock;*/
        }

        #endregion
        #region Getters/Setters
        public long IdProduct
        {
            get{ return idProduct; }
            set { idProduct = value; OnPropertyChanged(); }
        }
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
        public long IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; OnPropertyChanged(); }
        }
        /*public CategoryModel Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged(); }
        }*/
        public int QuantityAvailable
        {
            get { return quantityAvailable; }
            set { quantityAvailable = value; OnPropertyChanged(); }
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

        public long IdStateProduct
        {
            get { return idStateProduct; }
            set { idStateProduct = value; OnPropertyChanged(); }
        }

        /*public StateProductModel StateProduct
        {
            get { return stateProduct; }
            set { stateProduct = value; OnPropertyChanged(); }
        }*/

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }
        #endregion
    }
}