using Newtonsoft.Json;
using PetShopApp.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;

namespace PetShopApp.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
{
    private static ISettings AppSettings
    {
        get
        {
            return CrossSettings.Current;
        }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

    #endregion


    public static string GeneralSettings
    {
        get
        {
            return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
        }
        set
        {
            AppSettings.AddOrUpdateValue(SettingsKey, value);
        }
    }
        // Taked from = https://forums.xamarin.com/discussion/104610/how-do-i-check-if-user-is-logged-in-and-user-has-active-internet-connection-pcl-project
        public static string UEmail
        {
            get => AppSettings.GetValueOrDefault(nameof(UEmail), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(UEmail), value);
        }

        public static string UId
        {
            get => AppSettings.GetValueOrDefault(nameof(UId), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(UId), value);
        }

        private const string listProductsCartKey = "myintlist_key";
        public static List<Tuple<long,int>> listProductsCart
        {
            get
            {
                string value = AppSettings.GetValueOrDefault(listProductsCartKey, string.Empty);
                List<Tuple<long, int>> myList;
                if (string.IsNullOrEmpty(value))
                    myList = new List<Tuple<long, int>>();
                else
                    myList = JsonConvert.DeserializeObject<List<Tuple<long, int>>>(value);
                return myList;
            }
            set
            {
                string listValue = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue(listProductsCartKey, listValue);
            }
        }



    }
}