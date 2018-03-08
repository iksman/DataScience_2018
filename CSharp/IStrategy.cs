using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
  interface IStrategy {
     double algorithm(Tuple<Dictionary<int, float>, Dictionary<int,float>> data);

  }

  class StrategyContext
  {
    IStrategy strategy;
    public StrategyContext (IStrategy strategy) {
      this.strategy = strategy; 
    }

    public double algorithm(Tuple<Dictionary<int, float>, Dictionary<int, float>> data)
    {
      return this.strategy.algorithm(data);
    }


  }
}
