using Acr.UserDialogs;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    class ProductDetailViewModel : ViewModelBase
    {

        #region Commands
        public ICommand AddProductCommand { get; set; }
        public ICommand GoToCartCommand { get; set; }
        #endregion Commands

        #region Properties
        private ProductModel itemDetail;
            private int quantitySelected;
        #endregion Properties

        #region Getters & Setters
            public ProductModel ItemDetail
                {
                    get { return itemDetail; }
                    set
                    {
                        itemDetail =  value; OnPropertyChanged();
                    }
                }

            public int QuantitySelected
            {
                get { return quantitySelected; }
                set
                {
                quantitySelected = value; OnPropertyChanged();
                }
            }

        #endregion
        #region Initialization
        public ProductDetailViewModel()
        {
                AddProductCommand = new Command(async () => await AddProductToChart(), () => true);

                GoToCartCommand = new Command(async () => await GoToShoppingCart(), () => true);
        }
        public override async Task ConstructorAsync(object parameters)
        {

                
            var itemDetail = parameters as ProductModel;
            ItemDetail = itemDetail;
        }
        #endregion

        #region Methods
        private async Task AddProductToChart()
        {
            
            if (string.IsNullOrEmpty(Settings.UEmail))
            {
                
                //await UserDialogs.Instance.PromptAsync(promptConfig);
                await PopupNavigation.PushAsync(new LoginShopView());
            }
            else
            {
                /*var promptConfig = new PromptConfig();
                promptConfig.InputType = InputType.Name;
                promptConfig.IsCancellable = true;
                promptConfig.Message = Settings.UEmail +" "+itemDetail.Name;
                await UserDialogs.Instance.PromptAsync(promptConfig);*/
                //await Settings.ShoppingCartUser.AddItemToCart(ItemDetail);
                //Settings.ShoppingCartUser.ShowItemsFromCart();
                if (QuantitySelected >=1)
                {
                    var savedList = new List<Tuple<long, int>>(Settings.listProductsCart);
                    if (savedList.Any(p => p.Item1 == ItemDetail.IdProduct))
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "El producto ya está agregado en el carrito", "OK");


                    }
                    else
                    {
                        savedList.Add(new Tuple<long, int>(ItemDetail.IdProduct, QuantitySelected));
                        Settings.listProductsCart = savedList;
                        NavigationService.PopPage();
                    
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No puede agregar 0 cantidades", "OK");
                }

            }
            //NavigationService.PushPage(new CategoriesView());

        }
        private async Task GoToShoppingCart()
        {
            await NavigationService.PushPage(new ShoppingCartView());

        }


        #endregion

    }
}
