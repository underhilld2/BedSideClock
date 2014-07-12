namespace SharedLogicLibrary.Logic
{
   public class RandomLocationGenerator:PropertyChangeLogic
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
            NotifyPropertyChanged(() => MaxWidth);
         }
      }

   }
}