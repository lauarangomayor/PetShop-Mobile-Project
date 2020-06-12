using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Models
{
    class OrderCreatedModel : BaseModel
    {
        private float totalValue;
        private DateTime orderDate;
        private long idStateOrder;
        private long idClient;
        private List<ProductOrderModel> products;


        #region Setters & Getters
        public float TotalValue
        {
            get { return totalValue; }
            set
            {
                totalValue = value;
                OnPropertyChanged();
            }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
            set
            {
                orderDate = value;
                OnPropertyChanged();
            }
        }

        public long IdClient
        {
            get { return idClient; }
            set
            {
                idClient = value;
                OnPropertyChanged();
            }
        }

        public long IdStateOrder
        {
            get { return idStateOrder; }
            set
            {
                idStateOrder = value;
                OnPropertyChanged();
            }
        }

        public List<ProductOrderModel> Products
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
