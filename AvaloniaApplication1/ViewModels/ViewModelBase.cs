using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

public class ViewModelBase: ReactiveObject
{
  /// <summary>
  /// Alternative RaiseAndSetIfChanged implementation for use when the backing is not
  /// a local field but a property in another (host) object.
  /// </summary>
  /// <typeparam name="THost">
  /// The type of the host object
  /// </typeparam>
  /// <typeparam name="TRet">
  /// The type of the property value
  /// </typeparam>
  /// <param name="host">
  /// The host instance
  /// </param>
  /// <param name="backingAccessor">
  /// The lambda expression selecting the backing property in the host
  /// </param>
  /// <param name="newValue">
  /// The new value
  /// </param>
  /// <param name="propertyName">
  /// The name of the property (normally omitted to default to the calling property)
  /// </param>
  /// <returns>
  /// The newly set value
  /// </returns>
  public TRet RaiseAndSetIfChanged<THost,TRet>(
    THost host,
    Expression<Func<THost, TRet>> backingAccessor,
    TRet newValue,
    [CallerMemberName] string? propertyName = null)
    where THost : class
  {
    if(propertyName is null)
    {
      throw new ArgumentNullException(nameof(propertyName));
    }
    if(backingAccessor is null)
    {
      throw new ArgumentNullException(nameof(backingAccessor));
    }
    if(host is null)
    {
      throw new ArgumentNullException(nameof(host)); 
    }
    if(backingAccessor.Body is MemberExpression memberExpression 
      && memberExpression.Member is PropertyInfo property)
    {
      if(!property.CanWrite || !property.CanRead)
      {
        throw new InvalidOperationException("Expecting accessor to be a public read-write property accessor");
      }
      var oldValue = (TRet?)property.GetValue(host);
      if(EqualityComparer<TRet>.Default.Equals(oldValue, newValue))
      {
        return newValue;
      }
      this.RaisePropertyChanging(propertyName);
      property.SetValue(host, newValue, null);
      this.RaisePropertyChanged(propertyName);
      return newValue;
    }
    else
    {
      throw new InvalidOperationException("Expecting accessor to be a simple property accessor");
    }
  }

}
