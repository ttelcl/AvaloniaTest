/*
 * (c) 2023  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AvaloniaApplication1.DataModel;

using ReactiveUI;

namespace AvaloniaApplication1.ViewModels;

public class ThingyViewModel: ViewModelBase
{
  public ThingyViewModel(Thingy thingy)
  {
    Host = thingy;
  }

  public Thingy Host { get; init; }

  public Guid Id { get => Host.Id; }

  public int Sequence { get => Host.Sequence; }

  public bool IsChecked {
    get => Host.IsChecked;
    set { this.RaiseAndSetIfChanged(Host, host => host.IsChecked, value); }
  }

}
