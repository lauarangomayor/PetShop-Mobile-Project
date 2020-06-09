//using Acr.UserDialogs;
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

            ProductsList.Add(new ProductModel { ID = 1, Name = "Kit completo", Description="Incluye cepillos, cortauñas y un maletin.", UnitPrice = 53600,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 1, Image = "https://sc01.alicdn.com/kf/HTB1HZOiaLjsK1Rjy1Xaq6zispXaP.jpg" });
            ProductsList.Add(new ProductModel { ID = 2, Name = "Bowls de comida para perro", Description="Bolws metalicos para comida y agua", UnitPrice = 23000,Category= new CategoryModel { CategoryId = 2,Name= "Accesorios"}, Stock = 5, Image = "https://static2.abc.es/media/recreo/2019/02/21/Tiendanimal-plan-renove-mascotas-04-kExG--220x220@abc.PNG" });
            ProductsList.Add(new ProductModel { ID = 3, Name = "Kit limpieza petys", Description="Kit completo marca Petys para la liempieza de las necesidades de sus mascotas en el hogar.", UnitPrice = 5300,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 5, Image = "https://www.america-retail.com/static//2015/01/petys.png" });
            ProductsList.Add(new ProductModel { ID = 4, Name = "Perfume CanAmor", Description="Perfume Can Amor para perros.", UnitPrice = 17000,Category= new CategoryModel { CategoryId = 1,Name= "Aseo"}, Stock = 3, Image = "https://canamor.com/wp-content/uploads/2017/03/Perfume-Canino.jpg"});
            ProductsList.Add(new ProductModel { ID = 5, Name = "Collar de Smokin", Description="Collar en forma de smokin para gatos y perros.", UnitPrice = 1500,Category= new CategoryModel { CategoryId = 2, Name = "Accesorios" }, Stock = 2, Image = "https://ae01.alicdn.com/kf/H2d1daf13efa34b388de546682b18e5ceL/Collar-para-perro-y-gato-correa-ajustable-para-Collar-de-gato-accesorios-para-perros-mo-o.jpg" });
           ProductsList.Add(new ProductModel { ID = 14, Name = "Solución Advantix", Description="Solucion topca para perros de 10 kg a 25 kg", UnitPrice = 46600,Category= new CategoryModel { CategoryId = 3,Name= "Medicamentos"}, Stock = 8, Image = "https://mascotas.bayer.com.mx/static/media/images/upload/Productos/advantixgde-ectoparasiticida-ba13820-1.jpg" });
            
            

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
