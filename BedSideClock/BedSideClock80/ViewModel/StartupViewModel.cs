using System;
using BedSideClock.Logic;
using GalaSoft.MvvmLight;

namespace BedSideClock.ViewModel
{
   public class StartupViewModel : ViewModelBase
   {

      private ClockTimer _clockTimmer;
      public StartupViewModel()
      {
         _clockTimmer = new ClockTimer();
      }


      public ClockTimer CurrentDateTime
      {
         get { return _clockTimmer; }
      }
   }
}