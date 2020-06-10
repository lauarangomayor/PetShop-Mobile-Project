using Acr.UserDialogs;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
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
        #endregion Commands

        #region Properties
            private ProductModel itemDetail;
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

        #endregion
        #region Initialization
            public ProductDetailViewModel()
            {
                   AddProductCommand = new Command(async () => await AddProductToChart(), () => true);
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
                var promptConfig = new PromptConfig();
                promptConfig.InputType = InputType.Name;
                promptConfig.IsCancellable = true;
                promptConfig.Message = "Vacio";
                //await UserDialogs.Instance.PromptAsync(promptConfig);
                await PopupNavigation.PushAsync(new LoginShopView());
            }
            else
            {
                var promptConfig = new PromptConfig();
                promptConfig.InputType = InputType.Name;
                promptConfig.IsCancellable = true;
                promptConfig.Message = Settings.UEmail +" "+itemDetail.Name;
                await UserDialogs.Instance.PromptAsync(promptConfig);
                NavigationService.PopPage();
            }
            //NavigationService.PushPage(new CategoriesView());

        }


        #endregion

    }
}
