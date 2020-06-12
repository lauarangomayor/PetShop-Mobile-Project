using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Helpers;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    class CheckoutViewModel : ViewModelBase
    {
        private CheckoutModel checkoutItems;
        private OrderCreatedModel FinalOrder { get; set; }
        
        #region Request
        public RequestPicker<OrderCreatedModel> PostOrder { get; set; }
        #endregion


        #region Commands
        public ICommand CreateOrderCommand { get; set; }
        #endregion
        public CheckoutModel CheckoutItems
        {
            get { return checkoutItems; }
            set
            {
                checkoutItems = value;
                OnPropertyChanged();
            }
        }
        public CheckoutViewModel()
        {
            InitizalizeRequest();
            InitializeCommands();
        }
        public override async Task ConstructorAsync(object parameters)
        {


            var checkoutItems = parameters as CheckoutModel;
            CheckoutItems = checkoutItems;
        }

        #region Methods
        public void InitializeCommands()
        {
            CreateOrderCommand = new Command(async () => await CreateOrder(), () => true);
        }
        public async void InitizalizeRequest()
        {
            string urlPostCreatOorder = EndPoints.SERVER_URL + EndPoints.CREATE_ORDER;
            PostOrder = new RequestPicker<OrderCreatedModel>();
            PostOrder.StrategyPicker("POST", urlPostCreatOorder);

        }

        public async Task CreateOrder()
        {
            try
            {
                OrderCreatedModel order = new OrderCreatedModel()
                {
                    TotalValue = CheckoutItems.TotalValue,
                    OrderDate = DateTime.Now,
                    IdStateOrder = 1,
                    IdClient = CheckoutItems.IdClient,
                    Products = new List<ProductOrderModel>()

                };
                foreach (var item in CheckoutItems.Products)
                {
                        ProductOrderModel P = new ProductOrderModel
                        {
                            IdProduct = item.IdProduct,
                            QuantityBought = item.QuantitySelected
                        };
                        order.Products.Add(P);
                }
                APIResponse response = await PostOrder.ExecuteStrategy(order);
                if (response.IsSuccess)
                {
                    var savedList = new List<Tuple<long, int>>();
                    Settings.listProductsCart = savedList;
                    await NavigationService.PopPage();
                    await NavigationService.PopPage();
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
