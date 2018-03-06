using System;

namespace CSharp { 
  class Program {
    static void Main(string[] args) {
      IStrategy strategy1 = new ConcreteStrategy1();
      

      var data = DataParser.write2DArray("./userData.data", ",");

      DataParser.filterData(data, 1,4, false);


      Console.WriteLine(strategy1.algorithm());
      Console.ReadLine();
    }
  }
}
