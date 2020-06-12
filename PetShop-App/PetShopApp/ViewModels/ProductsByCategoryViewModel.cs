using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using PetShopApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class ProductsByCategoryViewModel : ViewModelBase
    {
        #region Properties
        private CategoryModel selectedCategory;
        public long IdCategory { get; set; }
        private List<ProductModel> products;
        private ObservableCollection<ProductModel> productsList;
        private ProductModel productItem;
        #endregion
        #region Requests
        public RequestPicker<BaseModel> GetProducts { get; set; }
        #endregion
        #region Commands
        public ICommand SelectedItemTappedCommand { get; set; }
        public ICommand GoToCartCommand { get; set; }
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
        public CategoryModel SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; OnPropertyChanged(); }
        }
        #endregion
        #region Initialization
        public ProductsByCategoryViewModel()
        {
            Products = new List<ProductModel>();
            ProductsList = new ObservableCollection<ProductModel>();
            InitializeCommands();
        }
        public override async Task ConstructorAsync(object parameters)
        {
            SelectedCategory = parameters as CategoryModel;
            InitializeRequests();
            //SelectedCategory = category;
        }
        #endregion
        #region Methods
        public async void InitializeRequests()
        {
            string urlGetProducts = EndPoints.SERVER_URL + EndPoints.GET_PRODUCTS_BY_CATEGORY + SelectedCategory.IdCategory.ToString();
            GetProducts = new RequestPicker<BaseModel>();
            GetProducts.StrategyPicker("GET", urlGetProducts);
            await ListProducts();
        }
        public void InitializeCommands()
        {
            SelectedItemTappedCommand = new Command(async () => await GoToProductDetails(), () => true);
            GoToCartCommand = new Command(async () => await GoToShoppingCart(), () => true);
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
                    p.UnitPriceString = p.UnitPrice.ToString("N0");
                    ProductsList.Add(p);
                }
            }
            else
            {
                Exception e;
            }

        }
        private async Task GoToProductDetails()
        {
            
            await NavigationService.PushPage(new ProductDetailView(), ProductItem);
            //ProductItem = null;


        }
        private async Task GoToShoppingCart()
        {
            
            await NavigationService.PushPage(new ShoppingCartView());

        }

        #endregion

    }
}
