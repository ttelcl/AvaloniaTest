﻿using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using AvaloniaApplication1.DependencyInjection;
using AvaloniaApplication1.Services;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;

using Splat;

namespace AvaloniaApplication1;

public partial class App: Application
{

  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    Bootstrapper.Register(Locator.CurrentMutable, Locator.Current);
    if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      desktop.MainWindow = new MainWindow {
        DataContext = new MainViewModel()
      };
    }
    else if(ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
    {
      singleViewPlatform.MainView = new MainView {
        DataContext = new MainViewModel()
      };
    }

    base.OnFrameworkInitializationCompleted();
  }
}
