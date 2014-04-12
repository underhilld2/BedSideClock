using System;
using System.Windows.Data;

namespace BedSideClock80.Converters
{
   public sealed class DateToStringFormatter : IValueConverter
   {
     public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         if (value is DateTime)
         {
            DateTime dt = (DateTime)value;

            if (parameter is string)
            {
               switch ((parameter as string).ToLower())
               {
                  case "datetime":
                     return string.Format("{0:MMMM dd, yyyy - h:mm tt}", dt);
                  case "date":
                     return string.Format("{0:MMMM dd, yyyy}", dt);
                  case "short":
                     return string.Format(" {0:MM/dd/yyyy}", dt);
                  case "time":
                     return string.Format(" {0:T}", dt);
               }
            }

            return dt.ToString();
         }

         return "";
      }

     public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         throw new NotImplementedException();
      }


   }
}
