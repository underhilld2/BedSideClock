using System.ComponentModel;

namespace SharedLogicLibrary.Logic
{
   public abstract class PropertyChangeLogic : INotifyPropertyChanged
   {

      public event PropertyChangedEventHandler PropertyChanged;
      protected void NotifyPropertyChanged(string property)
      {
         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
         }
      }
   }
}
