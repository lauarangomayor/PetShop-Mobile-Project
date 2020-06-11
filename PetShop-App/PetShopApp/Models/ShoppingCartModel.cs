using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PetShopApp.Services.Propagation;
using PetShopApp.Models;
using System.Threading.Tasks;

namespace PetShopApp.Models
{
    public class ShoppingCartModel : BaseModel
    {
        #region Properties
        private List<long> idProducts;
        #endregion

        #region Getters/Setters
        public List<long> IdProducts
        {
            get { return idProducts; }
            set
            {
                idProducts = value;
                OnPropertyChanged();
            }
        }
        #endregion
        /*
        public async Task ClearCart()
        {
            Products = null;
        }

        public async Task ShowItemsFromCart()
        {
            Products.ForEach(Console.Write);
        }*/
    }
}
