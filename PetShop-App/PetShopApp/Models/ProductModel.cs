using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    public class ProductModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private string name;
        private string description;
        private float price;
        private CategoryModel category;
        private int stock;
        #endregion
        #region Initialize
        public ProductModel(CategoryModel category, int stock)
        {
            if (category == null | stock < 0)
            {
                throw new System.ArgumentException("ProductModel received a null category or an invalid stock argument");
            }
            this.category = category;
            this.stock = stock;
        }
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
        public float Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
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

        #endregion
    }
}
