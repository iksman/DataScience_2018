using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

  class Euclidian : IStrategy {
    public double algorithm(Tuple<Dictionary<int, float>, Dictionary<int, float>> data) {
      double runningTotal = 0.0;
      foreach (var item in data.Item1) {
        var otherItem = data.Item2[item.Key];
        //Console.WriteLine(item.Key.ToString() + " -> " + item.Value.ToString() + " - " + otherItem.ToString());
        runningTotal += Math.Pow((item.Value - otherItem),2);
      }

      return (double) 1 / (1 + Math.Sqrt(runningTotal));
    }
  }

  class Manhattan : IStrategy {
    public double algorithm(Tuple<Dictionary<int, float>, Dictionary<int, float>> data) {
      double runningTotal = 0.0;
      foreach (var item in data.Item1) {
        var otherItem = data.Item2[item.Key];
        //Console.WriteLine(item.Key.ToString() + " -> " + item.Value.ToString() + " - " + otherItem.ToString());
        runningTotal += (item.Value - otherItem);
      }

      return (double) 1 / (1 + runningTotal);
    }
  }

  class Pearsson : IStrategy {
    public double algorithm(Tuple<Dictionary<int, float>, Dictionary<int, float>> data) {
      double x = 0;
      double y = 0;
      double a = 0;
      double b = 0;
      double c = 0;
      int n = 0;

      foreach (var item in data.Item1) {
        var otherItem = data.Item2[item.Key];
        n += 1;
        //Console.WriteLine(item.Key.ToString() + " -> " + item.Value.ToString() + " - " + otherItem.ToString());
        //runningTotal += (item.Value - otherItem);
        x += item.Value;
        y += otherItem;

        a += (item.Value * otherItem);
        b += (item.Value * item.Value);
        c += (otherItem * otherItem);

      }

      var topPart = (a - ((x * y) / n));
      var bottomPart = (Math.Sqrt(b - (Math.Pow(x, 2) / n))) * 
                       (Math.Sqrt(c - (Math.Pow(y, 2) / n)));

      return (double) topPart / bottomPart;
    }
  }
}
