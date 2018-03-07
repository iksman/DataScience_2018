using System;

namespace CSharp { 
  class Program {
    static void Main(string[] args) {
      
      printData(1, 2);
      printData(1, 3);


      Console.ReadLine();
    }

    static void printData(int user1, int user2) { 
      int[] users = {user1, user2};

      Data strategy1 = new Data(new Euclidian());
      Data strategy2 = new Data(new Manhattan());
      Data strategy3 = new Data(new Data( new Data(new Pearsson())));
      var data = DataParser.write2DArray("./userData.data", ",");

      data = DataParser.filterData(data, users[0], users[1], true);
      var noDelData = DataParser.filterData(data, users[0], users[1], false);

      var tuple = DataParser.splitDictionaries(data);
      
      Console.WriteLine("User " + users[0].ToString() + " -VS- User " + users[1].ToString());

      Console.WriteLine("Euclidian - " + strategy1.algorithm(tuple).ToString());
      Console.WriteLine("Manhattan - " + strategy2.algorithm(tuple).ToString());

      Console.WriteLine("Pearsson - " + strategy3.algorithm(DataParser.splitDictionaries(noDelData)).ToString());
      Console.WriteLine();
    }
  }
}
