/*
 * (c) 2023  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AvaloniaApplication1.Services;

using Splat;

namespace AvaloniaApplication1.DependencyInjection
{
  public static class Bootstrapper
  {
    // Inspired by:
    // https://dev.to/ingvarx/avaloniaui-dependency-injection-4aka
    // https://github.com/IngvarX/Camelot/blob/master/src/Camelot/DependencyInjection/ReadonlyDependencyResolverExtensions.cs

    /// <summary>
    /// Register services early in the bootstrap process (before any Avalonia and ReactivUI initialization)
    /// </summary>
    public static void PreRegister(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
    }

    /// <summary>
    /// Service registration during Avalonia and Reactive UI initialization
    /// </summary>
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
      services
        .RegisterLazySingletonAnd(() => new ThingyListService(5));
    }

    // Helper extension methods as workaround for Splat misdesign:
    public static TService GetRequiredService<TService>(this IReadonlyDependencyResolver resolver, string? contract = null)
    {
      var service = resolver.GetService<TService>(contract);
      return service is null
        ? throw new InvalidOperationException($"Failed to resolve object of type {typeof(TService)} (contract '{contract ?? String.Empty}')")
        : service;
    }

    public static object GetRequiredService(this IReadonlyDependencyResolver resolver, Type type, string? contract = null)
    {
      var service = resolver.GetService(type, contract);
      return service is null
        ? throw new InvalidOperationException($"Failed to resolve object of type {type} (contract '{contract ?? String.Empty}')")
        : service;
    }

  }
}
