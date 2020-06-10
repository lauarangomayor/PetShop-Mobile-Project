using Plugin.Settings;
using Plugin.Settings.Abstractions;

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

    }
}