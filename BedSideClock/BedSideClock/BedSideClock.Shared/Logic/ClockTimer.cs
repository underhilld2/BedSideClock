using System;
#if WINDOWS_APP || WINDOWS_PHONE_APP
using Windows.UI.Xaml;
#else
using System.Windows.Threading;
#endif
using SharedLogicLibrary.Logic;



namespace BedSideClock.Logic
{
   public class ClockTimer : PropertyChangeLogic, IClockTimer
   {
      private DispatcherTimer _dispatcherTimer;

      public ClockTimer()
      {
         this._dispatcherTimer = new DispatcherTimer();
         this._dispatcherTimer.Tick += dispatcherTimer_Tick;
         this._dispatcherTimer.Interval = new TimeSpan( 0, 0, 1 );
         this._dispatcherTimer.Start();
      }


      public void dispatcherTimer_Tick( object sender, object e )
      {
         NotifyPropertyChanged( "CurrentDateTime" );
      }

      public DateTime CurrentDateTime
      {
         get
         {
            return DateTime.Now;
         }
      }




   }
}

