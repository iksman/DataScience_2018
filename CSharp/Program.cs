using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp { 
  class Program { 
    static Dictionary<int,Dictionary<int,float>> getData() {
      return DataParser.write2DArray("./userItem.data",",");
      //return DataParser.write2DArray_MovieLens("./ratings.csv");
    }
    
    static void Main(string[] args) {

      printData(1,4);
      //printPrediction(186, new StrategyContext(new Pearsson()), 1);
      printNearest(1,new StrategyContext(new Pearsson()));
      //Console.WriteLine(ItemItem.deviations(31, 1172));
      //ItemItem.scale(new List<double>() { 2.5, 3, 4.25, 5 }, -3, 5);
      //Console.WriteLine(ItemItem.slopeOne(1, 101));

      Console.ReadLine();
    }

    static void printData(int user1, int user2) { 
      int[] users = {user1, user2};

      StrategyContext strategy1 = new StrategyContext(new Euclidian());
      StrategyContext strategy2 = new StrategyContext(new Manhattan());
      StrategyContext strategy3 = new StrategyContext(new Pearsson());
      StrategyContext strategy4 = new StrategyContext(new Cosine(), false);
      Dictionary<int,Dictionary<int,float>> data = Program.getData();

      data = DataParser.filterData(data, users[0], users[1], true);
      var noDelData = DataParser.filterData(data, users[0], users[1], false);

      if (data[users[0]].Values.Count == 0) {
        Console.WriteLine("There's no overlap between users " + user1.ToString() + " and " + user2.ToString());
      } else { 
        var tuple = DataParser.splitDictionaries(data);
        var noDelTuple = DataParser.splitDictionaries(noDelData);
      
        Console.WriteLine("User " + users[0].ToString() + " -VS- User " + users[1].ToString());

        Console.WriteLine("Euclidian - " + strategy1.algorithm(tuple).ToString());
        Console.WriteLine("Manhattan - " + strategy2.algorithm(tuple).ToString());
        Console.WriteLine("Pearsson - " + strategy3.algorithm(tuple).ToString());
        Console.WriteLine("Cosine   - " + strategy4.algorithm(noDelTuple));
        Console.WriteLine();
      }
    }

    static void printNearest(int target, StrategyContext strategy, int max=3) {
      var data = Program.getData();
      var NN = strategy.NearestNeighbor(data, target, 0.35, max);
      Console.WriteLine("Nearest Neighbors to " + NN.Item1.ToString() + " - " + strategy.strategy.GetType());
      
      

      foreach (var item in NN.Item2.OrderByDescending((variable) => variable.similarity)) {
        Console.WriteLine(item.userId.ToString() + " - " + item.similarity.ToString());
      }
      Console.WriteLine();     
    }

    static void printPrediction(int target, StrategyContext strategy, int productId = 101) {
      var data = Program.getData();

      Console.WriteLine("Predicted Rating user " + target.ToString() + " - Product " + productId.ToString() + " - " + strategy.PredictedRating(data, target, productId).ToString());
    }
  }
}
