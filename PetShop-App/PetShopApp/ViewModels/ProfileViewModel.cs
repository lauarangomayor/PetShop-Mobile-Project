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
using System.IO;
using PetShopApp.Helpers;

namespace PetShopApp.ViewModels
{
    class ProfileViewModel : ViewModelBase
    {
        #region Properties
        private List<OrderModel> orders;
        private ObservableCollection<OrderModel> ordersList;
        private UserModel userClient;
        #endregion
        #region Requests
        public RequestPicker<OrderModel> GetOrders { get; set; }

        public RequestPicker<UserModel> GetUserClient { get; set; }
        #endregion
        #region Commands

        #endregion
        #region Getters/Setters
        public List<OrderModel> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged(); }
        }
        public ObservableCollection<OrderModel> OrdersList
        {
            get { return ordersList; }
            set { ordersList = value; OnPropertyChanged(); }
        }
        public UserModel UserClient
        {
            get { return userClient; }
            set { userClient = value; OnPropertyChanged(); }
        }
        public ProfileViewModel()
        {
            Orders = new List<OrderModel>();
            OrdersList = new ObservableCollection<OrderModel>();
            InitizalizeRequest();
            InitializeCommands();
        }
        #endregion
        #region Methods
        public void InitializeCommands()
        {

        }
        public async void InitizalizeRequest()
        {
            string urlGetOrders = EndPoints.SERVER_URL + EndPoints.GET_ORDERS_BY_CLIENT + Settings.UId;
            GetOrders = new RequestPicker<OrderModel>();
            GetOrders.StrategyPicker("GET", urlGetOrders);
            await ListOrders();

            string urlGetClient = EndPoints.SERVER_URL + EndPoints.GET_USER_BY_CLIENT + Settings.UId;
            GetUserClient = new RequestPicker<UserModel>();
            GetUserClient.StrategyPicker("GET", urlGetClient);
            await UserClientGet();
        }
        public async Task UserClientGet() {
            APIResponse response = await GetUserClient.ExecuteStrategy(null);
            if (response.IsSuccess) {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                UserClient = JsonConvert.DeserializeObject<UserModel>(response.Response, jsonSerializerSettings);
            }
            
        }
        public async Task ListOrders() {
            APIResponse response = await GetOrders.ExecuteStrategy(null);
            if (response.IsSuccess) {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                Orders = JsonConvert.DeserializeObject<List<OrderModel>>(response.Response, jsonSerializerSettings);
                foreach (var o in Orders) {
                    OrdersList.Add(o);
                }
            }
        }
        #endregion

    }
}
