using PetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopApp.ViewModels
{
    class ProductDetailViewModel : ViewModelBase
    {
        private ProductModel itemDetail;

        public ProductModel ItemDetail
        {
            get { return itemDetail; }
            set
            {
                itemDetail =  value; OnPropertyChanged();
            }
        }
        public ProductDetailViewModel()
        {

        }

        public override async Task ConstructorAsync(object parameters)
        {
            var itemDetail = parameters as ProductModel;
            ItemDetail = itemDetail;
        }
    }
}
