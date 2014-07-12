using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

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
      protected void NotifyPropertyChanged<T>( Expression<Func<T>> property )
      {
         if ( PropertyChanged != null )
         {
            MemberExpression member = (MemberExpression) property.Body;
            Expression strExpr = member.Expression;
            string propertyName = member.Member.Name;
            PropertyChanged( this, new PropertyChangedEventArgs( property.Name ) );
         }
      }
   }
}
