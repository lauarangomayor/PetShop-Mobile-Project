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
    public class CategoriesViewModel : ViewModelBase
    {
        #region Properties
        private List<CategoryModel> categories;
        public ObservableCollection<CategoryModel> CategoriesList { get; set; }
        private CategoryModel selectedCategory;
        #endregion
        #region Commands
        public ICommand TappedCategoryCommand { get; set; }
        #endregion Commands
        #region Requests
        public RequestPicker<BaseModel> GetCategories { get; set; }
        #endregion
        #region Getters/Setters
        public CategoryModel SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; OnPropertyChanged(); }
        }
        public List<CategoryModel> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }
        #endregion
        #region Initialization
        public CategoriesViewModel()
        {
            CategoriesList = new ObservableCollection<CategoryModel>();
            Categories = new List<CategoryModel>();
            InitializeRequests();
            InitializeCommands();

            /*CategoriesList.Add(new CategoryModel { IdCategory = 1, Name = "Aseo" });
            CategoriesList.Add(new CategoryModel { IdCategory = 2, Name = "Accesorios" });
            CategoriesList.Add(new CategoryModel { IdCategory = 3, Name = "Medicamentos" });
            CategoriesList.Add(new CategoryModel { IdCategory = 4, Name = "Varios" });*/
        }
        #endregion
        #region Methods
        public async void InitializeRequests()
        {
            string urlGetCategories = EndPoints.SERVER_URL + EndPoints.GET_ALL_CATEGORIES;
            GetCategories = new RequestPicker<BaseModel>();
            GetCategories.StrategyPicker("GET", urlGetCategories);
            await ListCategories();
        }
        public void InitializeCommands()
        {
            TappedCategoryCommand = new Command(async () => await GoToProductByCategory(), () => true);
        }
        public async Task ListCategories()
        {
            APIResponse response = await GetCategories.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                Categories = JsonConvert.DeserializeObject<List<CategoryModel>>(response.Response);
                foreach (var c in Categories)
                {
                    CategoriesList.Add(c);
                }
            }
            else
            {
                Exception e;
            }
        }
        public async Task GoToProductByCategory()
        {
            /*CategoryModel ItemSelected = new CategoryModel();
            ItemSelected.IdCategory = SelectedCategory.IdCategory;
            ItemSelected.Name = SelectedCategory.Name;
            SelectedCategory = null;
            var i = 0;*/
            await NavigationService.PushPage(new ProductsByCategoryView(), SelectedCategory);
            
        }
        #endregion

    }

}
