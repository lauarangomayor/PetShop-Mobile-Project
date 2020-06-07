using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;

namespace PetShopApp.Moldels
{
    public class WishlistModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private List<ProductModel> products;
        #endregion
        #region Getters/Setters
        public List<ProductModel> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
