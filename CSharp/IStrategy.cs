using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
  interface IStrategy {
     double algorithm(Tuple<Dictionary<int, float>, Dictionary<int,float>> data);

  }

  class StrategyContext
  {
    IStrategy strategy;
    bool delete;
    public StrategyContext (IStrategy strategy, bool delete = true) {
      this.strategy = strategy; 
      this.delete = delete;
    }

    public double algorithm(Tuple<Dictionary<int, float>, Dictionary<int, float>> data)
    {
      return this.strategy.algorithm(data);
    }

    public Tuple<int,List<Neighbor>> NearestNeighbor(Dictionary<int,Dictionary<int,float>> data, int target, double threshold = 0.35, int amount = 3) {
      List<Neighbor> neighbors = new List<Neighbor>();
      if (data.ContainsKey(target)) { 
        foreach (var item in data) { 
          if (item.Key != target) {
            var filterData = DataParser.splitDictionaries(DataParser.filterData(data, target, item.Key, this.delete));

            double result = this.strategy.algorithm(filterData);
            
            if (result > threshold) {
              neighbors.Add(new Neighbor(item.Key, result));
              if (neighbors.Count > amount) {
                var lowestNeighbor = neighbors.Aggregate((item1, item2) => item1.similarity < item2.similarity ? item1 : item2);
                neighbors.Remove(lowestNeighbor);
              }
            }
          }
        }
        return new Tuple<int,List<Neighbor>>(target, neighbors);
      } else {
        return new Tuple<int, List<Neighbor>>(target, new List<Neighbor>());
      }
    }
  }
}
