using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp { 
  class Program {
    static void Main(string[] args) {
      
      //printData(1, 2);
      //printData(1, 3);
      printData(3,4);
      printNearest(7, new StrategyContext(new Pearsson()));
      printPrediction(7, new StrategyContext(new Pearsson()), 101);
      printPrediction(7, new StrategyContext(new Pearsson()), 103);
      printPrediction(7, new StrategyContext(new Pearsson()), 106);
      printPrediction(4, new StrategyContext(new Pearsson()), 101);
      printPrediction(7, new StrategyContext(new Pearsson()), 106);
      //printNearest(7, new StrategyContext(new Cosine(), false));
      //printNearest(7, new StrategyContext(new Euclidian()));
      Console.ReadLine();
    }

    static void printData(int user1, int user2) { 
      int[] users = {user1, user2};

      StrategyContext strategy1 = new StrategyContext(new Euclidian());
      StrategyContext strategy2 = new StrategyContext(new Manhattan());
      StrategyContext strategy3 = new StrategyContext(new Pearsson());
      StrategyContext strategy4 = new StrategyContext(new Cosine(), false);
      var data = DataParser.write2DArray("./userData.data", ",");

      data = DataParser.filterData(data, users[0], users[1], true);
      var noDelData = DataParser.filterData(data, users[0], users[1], false);

      var tuple = DataParser.splitDictionaries(data);
      var noDelTuple = DataParser.splitDictionaries(noDelData);
      
      Console.WriteLine("User " + users[0].ToString() + " -VS- User " + users[1].ToString());

      Console.WriteLine("Euclidian - " + strategy1.algorithm(tuple).ToString());
      //Console.WriteLine("Manhattan - " + strategy2.algorithm(tuple).ToString());
      Console.WriteLine("Pearsson - " + strategy3.algorithm(tuple).ToString());
      Console.WriteLine("Cosine   - " + strategy4.algorithm(noDelTuple));
      Console.WriteLine();
    }

    static void printNearest(int target, StrategyContext strategy) {
      var data = DataParser.write2DArray("./userData.data", ",");
      var NN = strategy.NearestNeighbor(data, target);
      Console.WriteLine("Nearest Neighbors to " + NN.Item1.ToString() + " - " + strategy.strategy.GetType());
      
      

      foreach (var item in NN.Item2.OrderByDescending((variable) => variable.similarity)) {
        Console.WriteLine(item.userId.ToString() + " - " + item.similarity.ToString());
      }
      Console.WriteLine();     
    }

    static void printPrediction(int target, StrategyContext strategy, int productId = 101) {
      var data = DataParser.write2DArray("./userData.data", ",");
      
      Console.WriteLine("Predicted Rating user " + target.ToString() + " - Product " + productId.ToString() + " - " + strategy.PredictedRating(data, target, productId).ToString());
    }
  }
}
