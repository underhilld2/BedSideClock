using Windows.ApplicationModel.Activation;

namespace BedSideClock.PhoneSessionManager.Interfaces
{

  #if WINDOWS_PHONE_APP
  /// <summary>
  ///   Implement this interface if your page invokes the folder picker API
  /// </summary>
  internal interface IFolderPickerContinuable
  {
    /// <summary>
    ///   This method is invoked when the folder picker returns the picked
    ///   folder
    /// </summary>
    /// <param name="args">Activated event args object that contains returned folder from folder picker</param>
    void ContinueFolderPicker(FolderPickerContinuationEventArgs args);
  }

#endif
}