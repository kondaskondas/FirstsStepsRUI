using System;
using System.Globalization;
using System.Windows.Data;

namespace FirstsStepsRUI.Models
{
    public class UserGroupConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? User.GetGroupName(UserGroup.Worker) : User.GetGroupName((UserGroup)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
