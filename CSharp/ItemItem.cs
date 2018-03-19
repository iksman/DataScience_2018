using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharp
{
  class ItemItem {
    public static double deviations(int productId1, int productId2) {
      var data = DataParser.write2DArray("./userData.data", ",");

      var filteredData = DataParser.filterTwoProducts(data, productId1, productId2);
      double result = 0f;
      foreach (var user in filteredData) {
        result += ((user.Value[productId1]) - (user.Value[productId2]));
      }
      return (result / filteredData.Count());
    }

    public static void scale(List<double> numbers, int min, int max) {
      int difference = max - min;
      foreach (double number in numbers) {
        double coeficient = number - min;
        Console.WriteLine(number.ToString() + " - " + (coeficient / difference).ToString());
      }
    }

    public static double slopeOne(int userId, int productId) {
      var data = DataParser.write2DArray("./userData.data", ",");
      List<int> products = DataParser.getProducts(data);
      products.Remove(productId);
      Dictionary<int, double> deviations = new Dictionary<int, double>();
      foreach (var item in products) {
        deviations.Add(item, ItemItem.deviations(productId, item));
      }

      //double averageDeviation = deviations.Average((item) => item.Value);
      //Console.WriteLine(averageDeviation);

      int counter = 0;
      double result = 0;
      foreach (var deviation in deviations) {
        if (data[userId].ContainsKey(deviation.Key) == true) {
          counter++;
          result += data[userId][deviation.Key] + deviation.Value;
        }
        
      }
      return (result/counter);
      
    }
  }
}
