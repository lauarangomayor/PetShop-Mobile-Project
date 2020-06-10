using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
        #region Properties
        private List<CategoryModel> categories;
        private List<StateProductModel> stateProduct;
        private ProductModel product;
        #endregion
        #region Requests
        public RequestPicker<BaseModel> GetCategories { get; set; }
        public RequestPicker<BaseModel> GetStateProduct { get; set; }
        public RequestPicker<ProductModel> PostProduct { get; set; }
        #endregion
        #region Attributes
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductIndexCategory { get; set; }
        public int ProductQuantityAvailable { get; set; }
        public  float ProductUnitPrice { get; set; }
        public int ProductIndexStateProduct { get; set; } 
        public string ProductImagePath { get; set; }
        #endregion
        
        #region Commands
        public ICommand CreateProductCommand { get; set; }
        #endregion
        #region Getters/Setters
        public List<CategoryModel> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }
        public List<StateProductModel> StateProducts
        {
            get { return stateProduct; }
            set
            {
                stateProduct = value;
                OnPropertyChanged();
            }
        }
        public ProductModel Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public CreateProductViewModel()
        {
            Categories = new List<CategoryModel>();
            StateProducts = new List<StateProductModel>();
            InitizalizeRequest();
            InitializeCommands();
        }
        #region Methods
        public void InitializeCommands()
        {
            CreateProductCommand = new Command(async () => await CreateProduct(), () => true);
        }
        public async void InitizalizeRequest()
        {
            string urlGetCategories = EndPoints.SERVER_URL + EndPoints.GET_ALL_CATEGORIES;
            GetCategories = new RequestPicker<BaseModel>();
            GetCategories.StrategyPicker("GET", urlGetCategories);
            await ListCategories();

            string urlGetProductStates = EndPoints.SERVER_URL + EndPoints.GET_ALL_STATESPRODUCT;
            GetStateProduct = new RequestPicker<BaseModel>();
            GetStateProduct.StrategyPicker("GET", urlGetProductStates);
            await ListStatesProduct();

            string urlPostCreateProduct = EndPoints.SERVER_URL + EndPoints.CREATE_PRODUCT;
            PostProduct = new RequestPicker<ProductModel>();
            PostProduct.StrategyPicker("POST", urlPostCreateProduct);
            
        }
        public async Task ListCategories()
        {
            APIResponse response = await GetCategories.ExecuteStrategy(null);
            if (response.IsSuccess){
                Categories = JsonConvert.DeserializeObject<List<CategoryModel>>(response.Response);
            }
            else
            {
                Exception e;
            }
        }
        public async Task ListStatesProduct()
        {
            APIResponse response = await GetStateProduct.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                StateProducts = JsonConvert.DeserializeObject<List<StateProductModel>>(response.Response);
            }
            else
            {
                Exception e;
            }
        }
        public async Task CreateProduct()
        {
            try
            {
                ProductModel product = new ProductModel()
                {
                    Name = ProductName,
                    Description = ProductDescription,
                    IdCategory = Categories[ProductIndexCategory].IdCategory,
                    QuantityAvailable = ProductQuantityAvailable,
                    UnitPrice= ProductUnitPrice,
                    IdStateProduct = StateProducts[ProductIndexStateProduct].IdStateProduct,
                    ImagePath = "C:/Windows/System32/"

                };
                APIResponse response = await PostProduct.ExecuteStrategy(product);
                if (response.IsSuccess)
                {
                    await NavigationService.PopPage();
                }
            }
            catch (Exception e)
            {

            }
        }
        #endregion

    }
}
