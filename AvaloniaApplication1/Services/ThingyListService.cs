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

namespace AvaloniaApplication1.Services;

public class ThingyListService
{
  private readonly Dictionary<Guid, Thingy> _thingies;

  public ThingyListService(int initialCount = 1)
  {
    _thingies = new Dictionary<Guid, Thingy>();
    AddNewThingies(initialCount);
    Debug.WriteLine($"Created ThingyListService with {_thingies.Count} thingies");
  }

  public void AddThingy(Thingy thingy)
  {
    _thingies[thingy.Id] = thingy;
  }

  public bool DeleteThingy(Guid thingyId)
  {
    return _thingies.Remove(thingyId);
  }

  public Thingy AddNewThingy()
  {
    var thingy = new Thingy(Guid.NewGuid());
    AddThingy(thingy);
    return thingy;
  }

  public IEnumerable<Thingy> AddNewThingies(int count)
  {
    return Enumerable.Range(0, count).Select(_ => AddNewThingy()).ToList();
  }

  public IEnumerable<Thingy> GetThingies()
  {
    return _thingies.Values;
  }
}
