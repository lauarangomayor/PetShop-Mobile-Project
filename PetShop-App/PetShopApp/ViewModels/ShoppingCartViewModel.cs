using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using PetShopApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    class ShoppingCartViewModel : ViewModelBase
    {
        private List<ShoppingCartShowModel> products;
        private ObservableCollection<ShoppingCartShowModel> productsList;
        private ShoppingCartShowModel productItem;
        private float total;
        private string totalString;
        #region Requests
        public RequestPicker<ShoppingCartModel> PostList { get; set; }
        public RequestPicker<UserModel> GetUserByClient { get; set; }
        #endregion

        #region Getters/Setters
        public List<ShoppingCartShowModel> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ShoppingCartShowModel> ProductsList
        {
            get { return productsList; }
            set
            {
                productsList = value;
                OnPropertyChanged();
            }
        }


        public ShoppingCartShowModel ProductItem
        {
            get { return productItem; }
            set { productItem = value; OnPropertyChanged(); }
        }

        public float Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged();
            }
        }

        public string TotalString
        {
            get { return totalString; }
            set
            {
                totalString = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand DeleteItemFromChart { get; set; }

        public ICommand GoToCheckoutCommand { get; set; }
        #endregion

        public ShoppingCartViewModel()
        {
            Products = new List<ShoppingCartShowModel>();
            ProductsList = new ObservableCollection<ShoppingCartShowModel>();
            Total = 0;
            InitizalizeRequest();
            InitializeCommands();
        }

        #region Methods

        public async void InitizalizeRequest()
        {
            string urlGetProductsByList = EndPoints.SERVER_URL + EndPoints.GET_PRODUCTS_OF_CHART;
            PostList = new RequestPicker<ShoppingCartModel>();
            PostList.StrategyPicker("POST", urlGetProductsByList);
            await ListProducts();

            string urlGetUserByClient = EndPoints.SERVER_URL + EndPoints.GET_USER_BY_CLIENT + Settings.UId;
            GetUserByClient = new RequestPicker<UserModel>();
            GetUserByClient.StrategyPicker("GET", urlGetUserByClient);

        }
        public void InitializeCommands()
        {
            DeleteItemFromChart = new Command <ShoppingCartShowModel>(async (itemDetail) => await DeleteProductFromChart(itemDetail), (itemDetail) => true);
            GoToCheckoutCommand = new Command(async () => await GoToCheckout(), () => true);

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
                Products = JsonConvert.DeserializeObject<List<ShoppingCartShowModel>>(response.Response);
                savedList = new List<Tuple<long,int>>(savedList.OrderBy(x => x.Item1));
                int cnt = 0;
                foreach (var product in Products)
                {
                    var items = savedList.ElementAt(cnt);
                    product.QuantitySelected = items.Item2;
                    product.UnitPriceString = product.UnitPrice.ToString("N0");
                    ProductsList.Add(product);
                    Total += (items.Item2 * product.UnitPrice);
                    cnt += 1;
                }
                
                TotalString = Total.ToString("N0");
                //await ShowProductsOfCart();
            }
            else
            {
                Exception e;
            }
        }

        public async Task DeleteProductFromChart(ShoppingCartShowModel itemDelete)
        {
            var savedList = new List<Tuple<long, int>>(Settings.listProductsCart);
            savedList = new List<Tuple<long, int>>(savedList.OrderBy(x => x.Item1));
            savedList.RemoveAll(x => x.Item1 == itemDelete.IdProduct);
            Settings.listProductsCart = savedList;
            ProductsList.Remove(itemDelete);
            int cnt = 0;
            Total = 0;
            foreach (var product in ProductsList)
            {
                var items = savedList.ElementAt(cnt);
   
                Total += (items.Item2 * product.UnitPrice);
                cnt += 1;
            }
            TotalString = Total.ToString("N0");


        }

        public async Task GoToCheckout()
        {
            APIResponse response = await GetUserByClient.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                UserModel User = JsonConvert.DeserializeObject<UserModel>(response.Response);
                CheckoutModel CheckOut = new CheckoutModel();
                CheckOut.Address = User.Address;
                CheckOut.IdClient = Convert.ToInt64(Settings.UId);
                CheckOut.TotalValue = Total;
                CheckOut.TotalValueString = TotalString;
                CheckOut.Products = new List<ShoppingCartShowModel>();
                foreach (var item in ProductsList)
                {
                    CheckOut.Products.Add(item);
                }
                NavigationService.PushPage(new CheckoutView(), CheckOut);
            }
            else
            {
                Exception e;
            }
            

        }
        #endregion
    }
}
