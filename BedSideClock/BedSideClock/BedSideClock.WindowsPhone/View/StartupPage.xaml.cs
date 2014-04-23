using Windows.ApplicationModel.Activation;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
using BedSideClock.Common;
using BedSideClock.PhoneSessionManager.Interfaces;


namespace BedSideClock.View
{
  /// <summary>
  ///   An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class StartupPage : BasePage, IFileOpenPickerContinuable
  {
    public static StartupPage Current;

    public StartupPage()
    {
      InitializeComponent();
    }



    private void AppBarButton_Click(object sender, RoutedEventArgs e)
    {
      var rootFrame = Window.Current.Content as Frame;
      rootFrame.Navigate(typeof (AlarmSettings));
    }

    private void BackgroundButton_Click(object sender, RoutedEventArgs e)
    {
      // Clear previous returned file name, if it exists, between iterations of this scenario
      OutputTextBlock.Text = "";

      var openPicker = new FileOpenPicker();
      openPicker.ViewMode = PickerViewMode.Thumbnail;
      openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
      openPicker.FileTypeFilter.Add(".jpg");
      openPicker.FileTypeFilter.Add(".jpeg");
      openPicker.FileTypeFilter.Add(".png");

      // Launch file open picker and caller app is suspended and may be terminated if required
      openPicker.PickSingleFileAndContinue();
    }

    public void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
    {
      if (args.Files.Count > 0)
      {
        OutputTextBlock.Text = "Picked photo: " + args.Files[0].Name;
      }
    }
  }
}