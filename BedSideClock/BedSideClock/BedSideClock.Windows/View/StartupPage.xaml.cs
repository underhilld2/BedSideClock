using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using BedSideClock.Common;

namespace BedSideClock.View
{
   /// <summary>
   /// An empty page that can be used on its own or navigated to within a Frame.
   /// </summary>
  public sealed partial class StartupPage : BasePage
   {

     public static StartupPage Current;
      public StartupPage()
      {
         this.InitializeComponent();
      }

      private async void BackgroundButton_Click(object sender, RoutedEventArgs e)
      {
        // Clear previous returned file name, if it exists, between iterations of this scenario
        OutputTextBlock.Text = "";

        FileOpenPicker openPicker = new FileOpenPicker();
        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
        openPicker.FileTypeFilter.Add(".jpg");
        openPicker.FileTypeFilter.Add(".jpeg");
        openPicker.FileTypeFilter.Add(".png");
        StorageFile file = await openPicker.PickSingleFileAsync();
        if (file != null)
        {
          // Application now has read/write access to the picked file
          OutputTextBlock.Text = "Picked photo: " + file.Name;
        }
        else
        {
          OutputTextBlock.Text = "Operation cancelled.";
        }
      }


   }
}
