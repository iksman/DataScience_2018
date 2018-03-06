using System;

namespace CSharp { 
  class Program {
    static void Main(string[] args) {
      IStrategy strategy1 = new Euclidian();
      IStrategy strategy2 = new Manhattan();
      IStrategy strategy3 = new Pearsson();


      var data = DataParser.write2DArray("./userData.data", ",");

      data = DataParser.filterData(data, 1,4, true);
      var noDelData = DataParser.filterData(data, 1,4, false);

      var tuple = DataParser.splitDictionaries(data);

      Console.WriteLine("Euclidian - " + strategy1.algorithm(tuple).ToString());
      Console.WriteLine("Manhattan - " + strategy2.algorithm(tuple).ToString());

      Console.WriteLine("Pearsson - " + strategy3.algorithm(DataParser.splitDictionaries(noDelData)).ToString());
      Console.ReadLine();
    }
  }
}
