using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace BedSideClock.Helpers
{
   public static class ImageHelpers
   {

      public static async Task<BitmapImage> LoadImage( StorageFile file )
      {
         BitmapImage bitmapImage = new BitmapImage();
         FileRandomAccessStream stream = (FileRandomAccessStream) await file.OpenAsync( FileAccessMode.Read );

         bitmapImage.SetSource( stream );

         return bitmapImage;

      }
   }

}
