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
        public RequestPicker<BaseModel> GetCategories { get; set; }
        public RequestPicker<BaseModel> GetStateProduct { get; set; }
        private List<CategoryModel> categories;
        private List<StateProductModel> stateProduct;
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
        public List<StateProductModel> StateProduct
        {
            get { return stateProduct; }
            set
            {
                stateProduct = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public CreateProductViewModel()
        {
            Categories = new List<CategoryModel>();
            StateProduct = new List<StateProductModel>();
            InitizalizeRequest();
        }
        #region Methods
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
                StateProduct = JsonConvert.DeserializeObject<List<StateProductModel>>(response.Response);
            }
            else
            {
                Exception e;
            }
        }
        #endregion

    }
}
