using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetShopApp.Views;

namespace PetShopApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ShopTabbedPage();
        }

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
