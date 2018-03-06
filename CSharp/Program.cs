using System;

namespace CSharp { 
  class Program {
    static void Main(string[] args) {
      IStrategy strategy1 = new ConcreteStrategy1();
      DataParser parser = new DataParser();

      var data = parser.write2DArray("./userData.data", ",");

      Console.WriteLine(strategy1.algorithm());
      Console.ReadLine();
    }
  }
}
