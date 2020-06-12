using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PetShopApp.Converters
{
    public class ConverterBase64ImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string base64Image = (string)value;

            if (base64Image == null)
                return null;
            var imageBytes = System.Convert.FromBase64String(base64Image);
            return ImageSource.FromStream(() => { return new MemoryStream(imageBytes); });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
