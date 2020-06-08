using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetShopApp.Views;
using PetShopApp.Services.Navigation;

namespace PetShopApp
{
    public partial class App : Application
    {
        #region Properties
        static NavigationService navigationService;
        #endregion
        public App()
        {
            InitializeComponent();

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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
