using SharedLogicLibrary.Logic;

namespace SharedLogicLibrary.RandomLocation
{
   public class RandomLocationGenerator : PropertyChangeLogic
   {


      private int _maxWidth;
      private int _maxHeight;
      private int _currentHorizontalLocation;
      private int _currentVerticalLocation;

      public int MaxWidth
      {

         get
         {
            return _maxWidth;

         }
         set
         {
            _maxWidth = value;
            NotifyPropertyChanged( () => MaxWidth );
         }
      }
      public int MaxHeight
      {

         get
         {
            return _maxHeight;

         }
         set
         {
            _maxHeight = value;
            NotifyPropertyChanged( () => MaxHeight );
         }
      }

      public int CurrentHorizontalLocation
      {
         get { return _currentHorizontalLocation; }
         set
         {
            _currentHorizontalLocation = value;
            NotifyPropertyChanged( () => CurrentHorizontalLocation );
         }
      }
      public int CurrentVerticalLocation
      {
         get
         {
            return _currentVerticalLocation;
         }
         set
         {
            _currentVerticalLocation = value;
            NotifyPropertyChanged( () => CurrentVerticalLocation );
         }
      }

      
   }
}