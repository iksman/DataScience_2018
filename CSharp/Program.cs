using System;

namespace CSharp { 
  class Program {
    static void Main(string[] args) {
      
      //printData(1, 2);
      //printData(1, 3);
      printData(3,4);


      Console.ReadLine();
    }

    static void printData(int user1, int user2) { 
      int[] users = {user1, user2};

      StrategyContext strategy1 = new StrategyContext(new Euclidian());
      StrategyContext strategy2 = new StrategyContext(new Manhattan());
      StrategyContext strategy3 = new StrategyContext(new Pearsson());
      StrategyContext strategy4 = new StrategyContext(new Cosine());
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
  }
}
