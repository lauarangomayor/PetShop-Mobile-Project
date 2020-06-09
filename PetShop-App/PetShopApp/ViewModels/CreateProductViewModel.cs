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
        public List<CategoryModel> CategoriesList { get; set; }
        private List<string> categories;
        #endregion
        #region Getters/Setters
        public List<string> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        //public ICommand ListCategoriesCommand { get; set; }
        #endregion
        public CreateProductViewModel()
        {
            Categories = new List<string>();
            InitizalizeRequest();
            
            //ListCategoriesCommand = new Command(async () => await ListCategories(), () => true);
        }
        #region Methods
        public async void InitizalizeRequest()
        {
            string urlGetCategories = EndPoints.SERVER_URL + EndPoints.GET_ALL_CATEGORIES;
            GetCategories = new RequestPicker<BaseModel>();
            GetCategories.StrategyPicker("GET", urlGetCategories);
            await ListCategories();
        }
        public async Task ListCategories()
        {
            APIResponse response = await GetCategories.ExecuteStrategy(null);
            if (response.IsSuccess){
                List<CategoryModel> categoriesList = JsonConvert.DeserializeObject<List<CategoryModel>>(response.Response);
                foreach (var c in categoriesList){
                    categories.Add(c.Name);
                }
            }
            else
            {
                var error = "Error al cargar categorías";
            }

        }
        #endregion

    }
}
