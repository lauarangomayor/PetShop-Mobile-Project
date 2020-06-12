using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    class CheckoutModel: BaseModel
    {
        #region Attributes
        private List<ShoppingCartShowModel> products;
        private float totalValue;
        private string totalValueString;
        private string address;
        private long idClient;
        #endregion

        #region Setters & Getters
        public List<ShoppingCartShowModel> Products
        {
            get { return products;}
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public float TotalValue
        {
            get { return totalValue; }
            set
            {
                totalValue = value;
                OnPropertyChanged();
            }
        }
        public string TotalValueString
        {
            get { return totalValueString; }
            set
            {
                totalValueString = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        public long IdClient
        {
            get {return idClient;}
            set
            {
                idClient = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
