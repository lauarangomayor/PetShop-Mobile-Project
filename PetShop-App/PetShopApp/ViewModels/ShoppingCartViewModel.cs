using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PetShopApp.ViewModels
{
    class ShoppingCartViewModel : ViewModelBase
    {
        private List<ProductModel> products;

        #region Requests
        public RequestPicker<ShoppingCartModel> PostList { get; set; }
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
        public ShoppingCartViewModel()
        {
            Products = new List<ProductModel>();
            InitizalizeRequest();
        }

        #region Methods

        public async void InitizalizeRequest()
        {
            string urlGetProductsByList = EndPoints.SERVER_URL + EndPoints.GET_PRODUCTS_OF_CHART;
            PostList = new RequestPicker<ShoppingCartModel>();
            PostList.StrategyPicker("POST", urlGetProductsByList);
            await ListProducts();
        }

        public async Task ListProducts()
        {
            var savedList = new List<Tuple<long, int>>(Settings.listProductsCart);
            List<long> ids = new List<long>();
            foreach(var idItem in savedList)
            {
                ids.Add(idItem.Item1);
            }
            ShoppingCartModel productsIds = new ShoppingCartModel()
            {
                IdProducts = ids
            };
            APIResponse response = await PostList.ExecuteStrategy(productsIds);
            if (response.IsSuccess)
            {
                Products = JsonConvert.DeserializeObject<List<ProductModel>>(response.Response);
            }
            else
            {
                Exception e;
            }
        }
        #endregion
    }
}
