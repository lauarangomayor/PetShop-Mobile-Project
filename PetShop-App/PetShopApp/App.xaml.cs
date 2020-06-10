using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetShopApp.Views;
using PetShopApp.Services.Navigation;
using PetShopApp.Helpers;

namespace PetShopApp
{
    public partial class App : Application
    {
        #region Properties
        static NavigationService navigationService;
        #endregion
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY5Mzk4QDMxMzgyZTMxMmUzMG1MN3U3NURvdEVZU00yaCt3U2N4dHFRQVBjc0I1S1lqdjVMNnkyVUtRTkU9");
            
            InitializeComponent();
            //MainPage = new NavigationPage(new ShopTabbedPage());
            MainPage = new NavigationPage(new StartPageView());
        }

        #region Getters/Setters
        public static NavigationService NavigationService
        {
            get
            {
                if (navigationService == null)
                {
                    navigationService = new NavigationService();
                }
                return navigationService;
            }
        }
        #endregion Getters/Setters

        protected override void OnStart()
        {
            Settings.UEmail = "";
            Settings.UId = "";
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}