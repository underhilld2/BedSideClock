using System;
using Windows.UI.Xaml;

namespace BedSideClock.Logic
{
   public class ClockTimer : PropertyChangeLogic
   {
      private DispatcherTimer _dispatcherTimer;

      public ClockTimer()
      {
         this._dispatcherTimer = new DispatcherTimer();
         this._dispatcherTimer.Tick += dispatcherTimer_Tick;
         this._dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
         this._dispatcherTimer.Start();
      }


      private void dispatcherTimer_Tick(object sender, object e)
      {
         NotifyPropertyChanged("CurrentDateTime");
         //NotifyPropertyChanged("CurrentTime");
      }

      public DateTime CurrentDateTime
      {
         get { return DateTime.Now; }
      }

      //public string CurrentTime
      //{
      //   get
      //   {
      //      return String.Format("{0:h:m:s tt}", DateTime.Now);
      //   }
      //}


   }
}

