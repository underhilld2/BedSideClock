using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BedSideClock.Common
{
  //this was done based on work if found in this blog post and helps
  // reduce the code in the code behind pages so that logic there is specific to the 
  // applicatoin and not house cleaning type stuff.
  //http://marcominerva.wordpress.com/2013/10/10/a-base-page-class-for-windows-8-1-store-apps-with-c-and-xaml/
  public class BasePage : Page
  {
    private readonly NavigationHelper navigationHelper;
    private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();


    public BasePage()
    {
      this.navigationHelper = new NavigationHelper(this);
      this.navigationHelper.LoadState += navigationHelper_LoadState;
      this.navigationHelper.SaveState += navigationHelper_SaveState;
    }

    public ObservableDictionary DefaultViewModel
    {
      get { return this.defaultViewModel; }
    }

    public NavigationHelper NavigationHelper
    {
      get { return this.navigationHelper; }
    }

    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
      LoadState(e);
    }

    private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
      SaveState(e);
    }

    protected virtual void LoadState(LoadStateEventArgs e) { }
    protected virtual void SaveState(SaveStateEventArgs e) { }

    #region NavigationHelper registration

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedTo(e);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      navigationHelper.OnNavigatedFrom(e);
    }

    #endregion
  }
}
