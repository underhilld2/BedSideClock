using Windows.ApplicationModel.Activation;

namespace BedSideClock.PhoneSessionManager.Interfaces
{

  #if WINDOWS_PHONE_APP
  /// <summary>
  ///   Implement this interface if your page invokes the file open picker
  ///   API.
  /// </summary>
  internal interface IFileOpenPickerContinuable
  {
    /// <summary>
    ///   This method is invoked when the file open picker returns picked
    ///   files
    /// </summary>
    /// <param name="args">Activated event args object that contains returned files from file open picker</param>
    void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args);
  }
#endif
}