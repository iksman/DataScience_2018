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
  }
}
