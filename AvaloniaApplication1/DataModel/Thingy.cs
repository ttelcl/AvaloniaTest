/*
 * (c) 2023  ttelcl / ttelcl
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.DataModel;

/// <summary>
/// Simplistic "item" model
/// </summary>
public class Thingy
{
  private static int __sequence = 0;

  public Thingy(Guid guid)
  {
    Id = guid;
    Sequence = ++__sequence;
    IsChecked = false;
  }

  public Guid Id { get; init; }

  public int Sequence { get; init; }

  public bool IsChecked {
    get => _isChecked;
    set {
      _isChecked = value;
      Debug.WriteLine($"Thingy {Id} / {Sequence} Checked = {_isChecked}");
    }
  }
  private bool _isChecked;
}
