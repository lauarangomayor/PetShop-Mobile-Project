using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    class ProductModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private string name;
        private string description;
        private float price;
        private CategoryModel category;
        private ProductStateModel state;
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
        public ProductStateModel State
        {
            get { return state; }
            set { state = value; OnPropertyChanged(); }
        }

        #endregion
    }
}
