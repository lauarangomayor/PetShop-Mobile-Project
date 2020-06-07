using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    public class ShoppingCartModel : NotificationObject
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        private List<ProductModel> products;
        public UserClientModel User { get; set; }
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
