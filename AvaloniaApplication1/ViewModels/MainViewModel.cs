
using Splat;

using AvaloniaApplication1.DependencyInjection;
using AvaloniaApplication1.Services;

namespace AvaloniaApplication1.ViewModels;

public class MainViewModel: ViewModelBase
{

  public MainViewModel() 
  { 
    Thingies = new ThingyListViewModel(Locator.Current.GetRequiredService<ThingyListService>());
  }

  public string Greeting => "Welcome to Avalonia!!";

  public ThingyListViewModel Thingies { get; init; }
}
