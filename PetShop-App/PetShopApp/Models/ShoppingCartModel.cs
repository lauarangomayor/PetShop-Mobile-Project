using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;

namespace PetShopApp.Models
{
    public class ShoppingCartModel : BaseModel
    {
        #region Properties
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
