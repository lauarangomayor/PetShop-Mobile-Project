using Newtonsoft.Json;
using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class UpdateProductViewModel : ViewModelBase
    {
        #region Properties 
        private ProductModel product;
        private List<CategoryModel> categories;
        private List<StateProductModel> stateProduct;
        private ImageSource image;
        private MemoryStream memoryStream;
        #endregion
        #region Getters/Setters
        public ProductModel Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }
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
        public ImageSource Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); }
        }
        public MemoryStream MemoryStream
        {
            get { return memoryStream; }
            set { memoryStream = value; OnPropertyChanged(); }
        }
        #endregion
        #region Commands
        public ICommand UpdateProductCommand { get; set; }
        public ICommand UploadImageCommand { get; set; }
        #endregion
        #region Attributes
        public int ProductIndexCategory { get; set; }
        public int ProductIndexStateProduct { get; set; }
        #endregion
        #region Requests
        public RequestPicker<BaseModel> GetCategories { get; set; }
        public RequestPicker<BaseModel> GetStateProduct { get; set; }
        public RequestPicker<ProductModel> PutProduct { get; set; }
        #endregion

        #region Initialization
        public UpdateProductViewModel()
        {
            Categories = new List<CategoryModel>();
            StateProducts = new List<StateProductModel>();
            MemoryStream = new MemoryStream();
            ProductIndexCategory = -1;
            ProductIndexStateProduct = -1;
            InitializeCommands();
        }
        public override async Task ConstructorAsync(object parameters)
        {
            Product = parameters as ProductModel;
            InitizalizeRequests();
        }
        #endregion
        #region Methods
        public async void InitizalizeRequests()
        {
            string urlGetCategories = EndPoints.SERVER_URL + EndPoints.GET_ALL_CATEGORIES;
            GetCategories = new RequestPicker<BaseModel>();
            GetCategories.StrategyPicker("GET", urlGetCategories);
            await ListCategories();

            string urlGetProductStates = EndPoints.SERVER_URL + EndPoints.GET_ALL_STATESPRODUCT;
            GetStateProduct = new RequestPicker<BaseModel>();
            GetStateProduct.StrategyPicker("GET", urlGetProductStates);
            await ListStatesProduct();

            string urlPutProduct = EndPoints.SERVER_URL + EndPoints.UPDATE_PRODUCT + Product.IdProduct.ToString();
            PutProduct = new RequestPicker<ProductModel>();
            PutProduct.StrategyPicker("PUT", urlPutProduct);
        }
        public void InitializeCommands()
        {
            UpdateProductCommand = new Command(async () => await ProductUpdate(), () => true);
            UploadImageCommand = new Command(async () => await UploadImage(), () => true);
        }
        public async Task ListCategories()
        {
            APIResponse response = await GetCategories.ExecuteStrategy(null);
            if (response.IsSuccess)
            {
                Categories = JsonConvert.DeserializeObject<List<CategoryModel>>(response.Response);
                /*int categoryIdxCounter = 0;
                foreach (var c in Categories)
                {
                    if (Product.IdCategory == c.IdCategory)
                    {
                        ProductIndexCategory = categoryIdxCounter;
                    }
                    categoryIdxCounter += 1;
                }*/
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
        public async Task UploadImage()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
            });

            if (file == null)
            {
                return;
            }
            /*Stream stream = file.GetStream();
            file.GetStream().CopyTo(memoryStream);
            file.Dispose();*/
            Image = ImageSource.FromStream(() =>
            {
                Stream stream = file.GetStream();
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                return stream;
            });
        }
        public async Task ProductUpdate()
        {
            string base64ToString = "";
            if (memoryStream.ToArray().Length != 0)
            {
                base64ToString = Convert.ToBase64String(memoryStream.ToArray());
            }
            else
            {
                base64ToString = Product.ImagePath;
            }
            memoryStream = new MemoryStream();
            try
            {
                if (ProductIndexCategory != -1)
                {
                    Product.IdCategory = Categories[ProductIndexCategory].IdCategory;
                }
                if (ProductIndexStateProduct != -1)
                {
                    Product.IdStateProduct = StateProducts[ProductIndexStateProduct].IdStateProduct;
                }
                ProductModel product = new ProductModel()
                {
                    IdProduct = Product.IdProduct,
                    Name = Product.Name,
                    Description = Product.Description,
                    IdCategory = Product.IdCategory,
                    QuantityAvailable = Product.QuantityAvailable,
                    UnitPrice = Product.UnitPrice,
                    IdStateProduct = Product.IdStateProduct,
                    ImagePath = base64ToString

                };
                APIResponse response = await PutProduct.ExecuteStrategy(product);
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
