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

            /* ProductsList.Add(new ProductModel { ID = 1, Name = "Kit completo", Description="Incluye cepillos, cortauñas y un maletin.", UnitPrice = 53600,Category= new CategoryModel { IdCategory = 1,Name= "Aseo"}, Stock = 1, Image = "https://sc01.alicdn.com/kf/HTB1HZOiaLjsK1Rjy1Xaq6zispXaP.jpg" });
             ProductsList.Add(new ProductModel { ID = 2, Name = "Bowls de comida para perro", Description="Bolws metalicos para comida y agua", UnitPrice = 23000,Category= new CategoryModel { IdCategory = 2,Name= "Accesorios"}, Stock = 5, Image = "https://static2.abc.es/media/recreo/2019/02/21/Tiendanimal-plan-renove-mascotas-04-kExG--220x220@abc.PNG" });
             ProductsList.Add(new ProductModel { ID = 3, Name = "Kit limpieza petys", Description="Kit completo marca Petys para la liempieza de las necesidades de sus mascotas en el hogar.", UnitPrice = 5300,Category= new CategoryModel { IdCategory = 1,Name= "Aseo"}, Stock = 5, Image = "https://www.america-retail.com/static//2015/01/petys.png" });
             ProductsList.Add(new ProductModel { ID = 4, Name = "Perfume CanAmor", Description="Perfume Can Amor para perros.", UnitPrice = 17000,Category= new CategoryModel { IdCategory = 1,Name= "Aseo"}, Stock = 3, Image = "https://canamor.com/wp-content/uploads/2017/03/Perfume-Canino.jpg"});
             ProductsList.Add(new ProductModel { ID = 5, Name = "Collar de Smokin", Description="Collar en forma de smokin para gatos y perros.", UnitPrice = 1500,Category= new CategoryModel { IdCategory = 2, Name = "Accesorios" }, Stock = 2, Image = "https://ae01.alicdn.com/kf/H2d1daf13efa34b388de546682b18e5ceL/Collar-para-perro-y-gato-correa-ajustable-para-Collar-de-gato-accesorios-para-perros-mo-o.jpg" });
             ProductsList.Add(new ProductModel { ID = 14, Name = "Solución Advantix", Description="Solucion topca para perros de 10 kg a 25 kg", UnitPrice = 46600,Category= new CategoryModel { IdCategory = 3,Name= "Medicamentos"}, Stock = 8, Image = "https://mascotas.bayer.com.mx/static/media/images/upload/Productos/advantixgde-ectoparasiticida-ba13820-1.jpg" });*/

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
