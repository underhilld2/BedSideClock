// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using BedSideClock.View;
using BedSideClock.WinPhoneSessionManagers;

namespace BedSideClock
{
  /// <summary>
  ///   Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  sealed partial class App : Application
  {
#if WINDOWS_PHONE_APP
    private ContinuationManager continuationManager;
#endif


    /// <summary>
    ///   Initializes the singleton Application object.  This is the first line of authored code
    ///   executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
      InitializeComponent();
      Suspending += OnSuspending;

#if WINDOWS_PHONE_APP
      HardwareButtons.BackPressed += HardwareButtons_BackPressed;
#endif
    }


#if WINDOWS_PHONE_APP
    private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
      Frame rootFrame = Window.Current.Content as Frame;

      if (rootFrame != null)
      {
        if (rootFrame.CanGoBack)
        {
          rootFrame.GoBack();
          e.Handled = true;
        }
      }
    }
#endif
    private Frame CreateRootFrame()
    {
      var rootFrame = Window.Current.Content as Frame;

      // Do not repeat app initialization when the Window already has content,
      // just ensure that the window is active
      if (rootFrame == null)
      {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        // Set the default language
        rootFrame.Language = ApplicationLanguages.Languages[0];
        rootFrame.NavigationFailed += OnNavigationFailed;

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
      }

      return rootFrame;
    }

    private async Task RestoreStatusAsync(ApplicationExecutionState previousExecutionState)
    {
      // Do not repeat app initialization when the Window already has content,
      // just ensure that the window is active
      if (previousExecutionState == ApplicationExecutionState.Terminated)
      {
        // Restore the saved session state only when appropriate
        try
        {
          await SuspensionManager.RestoreAsync();
        }
        catch (SuspensionManagerException)
        {
          //Something went wrong restoring state.
          //Assume there is no state and continue
        }
      }
    }

#if WINDOWS_PHONE_APP
    /// <summary>
    ///   Handle OnActivated event to deal with File Open/Save continuation activation kinds
    /// </summary>
    /// <param name="e">Application activated event arguments, it can be casted to proper sub-type based on ActivationKind</param>
    protected override async void OnActivated(IActivatedEventArgs e)
    {
      base.OnActivated(e);

      continuationManager = new ContinuationManager();

      Frame rootFrame = CreateRootFrame();
      await RestoreStatusAsync(e.PreviousExecutionState);

      if (rootFrame.Content == null)
      {
        rootFrame.Navigate(typeof (StartupPage));
      }

      var continuationEventArgs = e as IContinuationActivatedEventArgs;
      if (continuationEventArgs != null)
      {
        //var scenarioFrame = StartupPage.Current.FindName("ScenarioFrame") as Frame;
        //if (scenarioFrame != null)
        //{
          // Call ContinuationManager to handle continuation activation
          continuationManager.Continue(continuationEventArgs);
        //}
      }

      Window.Current.Activate();
    }
#endif

    /// <summary>
    ///   Invoked when the application is launched normally by the end user.  Other entry points
    ///   will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="e">Details about the launch request and process.</param>
    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    {
      Frame rootFrame = CreateRootFrame();
      await RestoreStatusAsync(e.PreviousExecutionState);

      //MainPage is always in rootFrame so we don't have to worry about restoring the navigation state on resume
      rootFrame.Navigate(typeof (StartupPage), e.Arguments);

      // Ensure the current window is active
      Window.Current.Activate();
    }

    /// <summary>
    ///   Invoked when Navigation to a certain page fails
    /// </summary>
    /// <param name="sender">The Frame which failed navigation</param>
    /// <param name="e">Details about the navigation failure</param>
    private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }

    /// <summary>
    ///   Invoked when application execution is being suspended.  Application state is saved
    ///   without knowing whether the application will be terminated or resumed with the contents
    ///   of memory still intact.
    /// </summary>
    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    private async void OnSuspending(object sender, SuspendingEventArgs e)
    {
      SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
      await SuspensionManager.SaveAsync();
      deferral.Complete();
    }
  }
}