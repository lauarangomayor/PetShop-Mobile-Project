//using Acr.UserDialogs;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using PetShopApp.Views;
using PetShopApp.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PetShopApp.AuxModels;
using Newtonsoft.Json;

namespace PetShopApp.ViewModels
{
    class HomeShopViewModel : ViewModelBase
    {
        #region Properties
        private List<ProductModel> products;
        private ObservableCollection<ProductModel> productsList;
        private ProductModel productItem;
        #endregion
        #region Requests
        public RequestPicker<BaseModel> GetProducts { get; set; }
        public RequestPicker<BaseModel> GetStateProduct { get; set; }
        public RequestPicker<ProductModel> PostProduct { get; set; }
        #endregion
        #region Attributes
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductIndexCategory { get; set; }
        public int ProductQuantityAvailable { get; set; }
        public float ProductUnitPrice { get; set; }
        public int ProductIndexStateProduct { get; set; }
        public string ProductImagePath { get; set; }
        #endregion

        #region Commands
        public ICommand SelectedItemTappedCommand { get; set; }
        #endregion
        #region Getters/Setters
        public ObservableCollection<ProductModel> ProductsList
        {
            get { return productsList; }
            set { productsList = value; OnPropertyChanged(); }
        }
        public ProductModel ProductItem
        {
            get { return productItem; }
            set { productItem = value; OnPropertyChanged(); }
        }
        public List<ProductModel> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(); }
        }
        #endregion
        public HomeShopViewModel()
        {
            Products = new List<ProductModel>();
            ProductsList = new ObservableCollection<ProductModel>();
            InitizalizeRequest();
            InitializeCommands();
        }
        #region Methods
        public void InitializeCommands()
        {
            SelectedItemTappedCommand = new Command(async () => await GoToProductDetails(), () => true);
        }
        public async void InitizalizeRequest()
        {
            string urlGetProducts = EndPoints.SERVER_URL + EndPoints.GET_ALL_PRODUCTS;
            GetProducts = new RequestPicker<BaseModel>();
            GetProducts.StrategyPicker("GET", urlGetProducts);
            await ListProducts();
        }
        private async Task GoToProductDetails()
        {
            /*
            var promptConfig = new PromptConfig();
            promptConfig.InputType = InputType.Name;
            promptConfig.IsCancellable = true;
            promptConfig.Message = productItem.Name;
            var result = await UserDialogs.Instance.PromptAsync(promptConfig);*/
            await NavigationService.PushPage(new ProductDetailView(), ProductItem );
        }
        public async Task ListProducts()
        {
            APIResponse response = await GetProducts.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Products = JsonConvert.DeserializeObject<List<ProductModel>>(response.Response, jsonSerializerSettings);
                foreach (var p in Products)
                {
                    ProductsList.Add(p);
                }

            }
            else
            {
                Exception e;
            }
        }
        #endregion

    }
}
