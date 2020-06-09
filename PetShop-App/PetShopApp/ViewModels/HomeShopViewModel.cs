using Acr.UserDialogs;
using PetShopApp.Models;
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
    class HomeShopViewModel : ViewModelBase
    {
        #region Commands
        public ICommand SelectedItemTappedCommand { get; set; }
        #endregion
        public ObservableCollection<ProductModel> ProductsList { get; set; }
        public ProductModel productItem { get; set; }
        public HomeShopViewModel()
        {
            SelectedItemTappedCommand = new Command(async () => await GoToProductDetails(), () => true);
            ProductsList = new ObservableCollection<ProductModel>();

            ProductsList.Add(new ProductModel { ID = 1, Name = "Test1", Description="Super producto Wow 1", UnitPrice = 5000,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 2, Name = "Test2", Description="Super producto Wow 2", UnitPrice = 15000,Category= new CategoryModel { CategoryId = 2,Name= "Accesorios"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 3, Name = "Test3", Description="Super producto Wow 3", UnitPrice = 5300,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 4, Name = "Test4", Description="Super producto Wow 4", UnitPrice = 7000,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 5, Name = "Test5", Description="Super producto Wow 5", UnitPrice = 500,Category= new CategoryModel { CategoryId = 2, Name = "Accesorios" }, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 6, Name = "Test6", Description="Super producto Wow 6", UnitPrice = 1000,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 7, Name = "Test7", Description="Super producto Wow 7", UnitPrice = 23000,Category= new CategoryModel { CategoryId = 2, Name = "Accesorios" }, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 8, Name = "Test8", Description="Super producto Wow 8", UnitPrice = 35600,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 9, Name = "Test9", Description="Super producto Wow 9", UnitPrice = 51000,Category= new CategoryModel { CategoryId = 2, Name = "Accesorios" }, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 10, Name = "Test10", Description="Super producto Wow 10", UnitPrice = 54400,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 11, Name = "Test11", Description="Super producto Wow 11", UnitPrice = 4200,Category= new CategoryModel { CategoryId = 2, Name = "Accesorios" }, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 12, Name = "Test12", Description="Super producto Wow 12", UnitPrice = 4050,Category= new CategoryModel { CategoryId = 2, Name = "Accesorios" }, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 13, Name = "Test13", Description="Super producto Wow 13", UnitPrice = 10000,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            ProductsList.Add(new ProductModel { ID = 14, Name = "Test14", Description="Super producto Wow 14", UnitPrice = 46600,Category= new CategoryModel { CategoryId = 3,Name= "Medicamentos"}, Stock = 5, Image = "https://image.shutterstock.com/image-photo/fresh-tasty-burger-isolated-on-260nw-705104968.jpg"});
            
            

        }
        #region Methods
        private async Task GoToProductDetails()
        {
            /*
            var promptConfig = new PromptConfig();
            promptConfig.InputType = InputType.Name;
            promptConfig.IsCancellable = true;
            promptConfig.Message = productItem.Name;
            var result = await UserDialogs.Instance.PromptAsync(promptConfig);*/
            await NavigationService.PushPage(new ProductDetailView(), productItem );
        }
        #endregion

    }
}
