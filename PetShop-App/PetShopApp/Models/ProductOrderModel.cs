using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    class ProductOrderModel : BaseModel
    {
        private long idProduct;
        private int quantityBought;

        public long IdProduct
        {
            get { return idProduct; }
            set
            {
                idProduct = value;
                OnPropertyChanged();
            }
        }

        public int QuantityBought
        {
            get { return quantityBought; }
            set
            {
                quantityBought = value;
                OnPropertyChanged();
            }
        }
    }
}
