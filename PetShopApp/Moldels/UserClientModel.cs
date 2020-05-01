using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Moldels
{
    class UserClientModel : PersonModel
    {
        #region Properties
        private OrderModel order;
        private WishlistModel wishlist;
        private ShoppingCarModel car;
        private List<OrderModel> orderRecord;
        #endregion
        #region Getters/Setters
        public OrderModel Order
        {
            get { return order; }
            set { order = value; OnPropertyChanged(); }
        }
        public WishlistModel Wishlist
        {
            get { return wishlist; }
            set { wishlist = value; OnPropertyChanged(); }
        }
        public ShoppingCarModel Car
        {
            get { return car; }
            set { car = value; OnPropertyChanged(); }
        }
        public List<OrderModel> OrderRecord
        {
            get { return orderRecord; }
            set { orderRecord = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
