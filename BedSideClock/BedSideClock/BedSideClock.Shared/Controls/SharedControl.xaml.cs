﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
#if WINDOWS_APP || WINDOWS_PHONE_APP
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#else
using System.Windows.Controls;
#endif

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236


namespace BedSideClock.Controls
{
   public sealed partial class SharedControl : UserControl
   {
      public SharedControl()
      {
         InitializeComponent();
      }
   }
}
