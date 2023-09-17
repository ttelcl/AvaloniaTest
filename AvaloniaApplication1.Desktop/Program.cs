using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;

using Splat;

using AvaloniaApplication1.DependencyInjection;

namespace AvaloniaApplication1.Desktop;

class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static void Main(string[] args)
  {
    Bootstrapper.PreRegister(Locator.CurrentMutable, Locator.Current);
    BuildAvaloniaApp()
      .StartWithClassicDesktopLifetime(args, ShutdownMode.OnMainWindowClose);
  }

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp()
      => AppBuilder.Configure<App>()
          .UsePlatformDetect()
          .WithInterFont()
          .LogToTrace()
          .UseReactiveUI();
}
