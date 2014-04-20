using Windows.ApplicationModel.Activation;

namespace BedSideClock.PhoneSessionManager.Interfaces
{

  #if WINDOWS_PHONE_APP

  /// <summary>
  /// Implement this interface if your page invokes the web authentication
  /// broker
  /// </summary>
  internal interface IWebAuthenticationContinuable
  {
    /// <summary>
    /// This method is invoked when the web authentication broker returns
    /// with the authentication result
    /// </summary>
    /// <param name="args">Activated event args object that contains returned authentication token</param>
    void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args);
  }

#endif
}
