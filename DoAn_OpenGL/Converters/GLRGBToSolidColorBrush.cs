using DoAn_OpenGL.Graphics3D;
using System;
using System.Windows.Data;
using System.Windows.Media;

namespace DoAn_OpenGL.Converters
{
    public class GLRGBToSolidColorBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
                Graphic3D v = value as Graphic3D;
            if (v is null)
                return null;
            return new SolidColorBrush(Color.FromArgb(255, System.Convert.ToByte(v.ColorR * 255.0), System.Convert.ToByte(v.ColorG * 255), System.Convert.ToByte(v.ColorB * 255)));
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}