using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
  class Printer
  {
    public static void printData(int user1, int user2)
    {
      int[] users = { user1, user2 };

      StrategyContext strategy1 = new StrategyContext(new Euclidian());
      StrategyContext strategy2 = new StrategyContext(new Manhattan());
      StrategyContext strategy3 = new StrategyContext(new Pearsson());

      var data = DataParser.filterData(DataParser.write2DArray("./userData.data", ","), users[0], users[1], true);  
      var dataNoDel = DataParser.filterData(data, users[0], users[1], false);

      var tuple = DataParser.splitDictionaries(data);
      var tupleNoDel = DataParser.splitDictionaries(dataNoDel);

      ////////////////////// FRONTEND \\\\\\\\\\\\\\\\\\\\\\
      
      Console.WriteLine("User " + users[0].ToString() + " -VS- User " + users[1].ToString());

      Console.WriteLine("Euclidian - " + strategy1.algorithm(tuple).ToString());
      Console.WriteLine("Manhattan - " + strategy2.algorithm(tuple).ToString());
      Console.WriteLine("Pearsson - " + strategy3.algorithm(tupleNoDel).ToString());

      Console.WriteLine();
    }
  }
}
