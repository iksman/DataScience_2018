using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
  interface IStrategy {
     double algorithm(Tuple<Dictionary<int, float>, Dictionary<int,float>> data);
  }

  class Data : IStrategy
  {
    IStrategy strategy;
    public Data (IStrategy strategy) {
      this.strategy = strategy; 
    }

    public double algorithm(Tuple<Dictionary<int, float>, Dictionary<int, float>> data)
    {
      return this.strategy.algorithm(data);
    }
  }
}
