/*
 * (c) 2023  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AvaloniaApplication1.DataModel;
using AvaloniaApplication1.Services;

namespace AvaloniaApplication1.ViewModels;

public class ThingyListViewModel: ViewModelBase
{
  private readonly ThingyListService _thingyService;

  public ThingyListViewModel(ThingyListService thingyService)
  {
    _thingyService = thingyService;
    Things = new ObservableCollection<ThingyViewModel>(
      _thingyService.GetThingies().Select(t => new ThingyViewModel(t)));
  }

  public void AddMoreThingies(int count)
  {
    foreach(var thingy in _thingyService.AddNewThingies(count))
    {
      Things.Add(new ThingyViewModel(thingy));
    }
  }

  public void AddBatchOfThingies()
  {
    AddMoreThingies(3);
  }

  public ObservableCollection<ThingyViewModel> Things { get; init; }

}