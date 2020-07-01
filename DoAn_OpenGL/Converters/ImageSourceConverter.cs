using System;
using System.Windows.Data;

namespace DoAn_OpenGL.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is string)
            {
                string v = (string)value;
                if(!string.IsNullOrEmpty(v))
                {
                    if(!string.IsNullOrWhiteSpace(v))
                    {
                        return string.Format("pack://application:,,,/DoAn_OpenGL;component/Assets/Images/{0}.png", v.Split('.')[0].Trim());
                    }    
                }    
            }
            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}