using Windows.ApplicationModel.Activation;

namespace BedSideClock.PhoneSessionManager.Interfaces
{

  #if WINDOWS_PHONE_APP
  /// <summary>
  ///   Implement this interface if your page invokes the file save picker
  ///   API
  /// </summary>
  internal interface IFileSavePickerContinuable
  {
    /// <summary>
    ///   This method is invoked when the file save picker returns saved
    ///   files
    /// </summary>
    /// <param name="args">Activated event args object that contains returned file from file save picker</param>
    void ContinueFileSavePicker(FileSavePickerContinuationEventArgs args);
  }
#endif
}