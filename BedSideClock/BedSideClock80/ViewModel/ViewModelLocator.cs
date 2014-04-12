﻿using BedSideClock.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace BedSideClock80.ViewModel
{
   public class ViewModelLocator
   {
      public StartupViewModel StartupPageVM
      {
         get
         {
            return ServiceLocator.Current.GetInstance<StartupViewModel>();
         }
      }

      static ViewModelLocator()
      {
         ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
         SimpleIoc.Default.Register<StartupViewModel>();
      }
   }
}
