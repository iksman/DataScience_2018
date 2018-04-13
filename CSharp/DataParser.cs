using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace CSharp
{
  class DataParser
  {
    public static string[] writeArray(string filename) {
      return System.IO.File.ReadAllLines(filename);
    }

    public static Dictionary<int,Dictionary<int, double>> write2DArray(string filename, string split) {
      string[] data = writeArray(filename);
      var result = new Dictionary<int,Dictionary<int, double>>();
      Dictionary<int, double> score;

      foreach (string line in data) {
        string[] lineResult = line.Split(split);
        score = new Dictionary<int, double>();
        score.Add(int.Parse(lineResult[1]),  double.Parse(lineResult[2]));

        if ( result.TryAdd( int.Parse(lineResult[0]), score)) {
        } else {
          result[int.Parse(lineResult[0])].Add(int.Parse(lineResult[1]), double.Parse(lineResult[2]) / 10);
        }
      }

      return result;
    }



    public static Dictionary<int,Dictionary<int, double>> write2DArray_MovieLens(string filename) { 
      string[] data = writeArray(filename).Skip(1).ToArray(); //Skip first item because first line is definition as it is a csv.
      var result = new Dictionary<int, Dictionary<int, double>>();
      
      foreach (string line in data) {
        string[] lineResult = line.Split(',');
        Dictionary<int, double> score = new Dictionary<int, double>();
        score.Add(int.Parse(lineResult[1]), double.Parse(lineResult[2]));

        if (result.TryAdd(int.Parse(lineResult[0]), score)) { 
        } else {
          result[int.Parse(lineResult[0])].Add(int.Parse(lineResult[1]), double.Parse(lineResult[2]) / 10);
        }
      }
      return result;
    }

    public static List<int> getProducts(Dictionary<int, Dictionary<int, double>> data) {
      List<int> result = new List<int>();
      foreach (var user in data) {
        foreach (var product in user.Value) {
          if (result.Contains(product.Key) != true) { 
            result.Add(product.Key);
          }
        }
      }
      result.Sort();
      return result;
    }

    public static Dictionary<int, Dictionary<int, double>> filterRatings(Dictionary<int, Dictionary<int, double>> data, int productId) {
      Dictionary<int, Dictionary<int, double>> result = new Dictionary<int, Dictionary<int, double>>();
      foreach (var user in data) {
        if (user.Value.ContainsKey(productId)) {
          result.Add(user.Key, user.Value);
        }
      }
      return result;
    }
    
    public static Dictionary<int, Dictionary<int, double>> filterTwoProducts(Dictionary<int, Dictionary<int, double>> data, int productId1, int productId2) {
      Dictionary<int, Dictionary<int, double>> result = new Dictionary<int, Dictionary<int, double>>();
      foreach (var user in data) {
        if (user.Value.ContainsKey(productId1) && user.Value.ContainsKey(productId2)) {
          result.Add(user.Key, user.Value);
        }
      }
      return result;
    }

    public static Dictionary<int, Dictionary<int, double>> filterRatings(Dictionary<int, Dictionary<int, double>> data, int productId, int target) {
      Dictionary<int, Dictionary<int, double>> result = new Dictionary<int, Dictionary<int, double>>();
      foreach (var user in data) {
        if (user.Key == target) {
          result.Add(user.Key, user.Value);
        }else if (user.Value.ContainsKey(productId)) {
          result.Add(user.Key, user.Value);
        }
      }
      return result;
    }

    public static void checkData(Dictionary<int, Dictionary<int, double>> data) {
    }

    public static Dictionary<int,Dictionary<int, double>> filterData(Dictionary<int,Dictionary<int, double>> data, int keyX, int keyY, bool delete=true) {
      var firstUser = data[keyX];
      var secondUser = data[keyY];
      
      var result = new Dictionary<int, Dictionary<int, double>>();
      
      if (delete == true) {

        var firstResult = new Dictionary<int, double>();
        var secondResult = new Dictionary<int, double>();

        foreach (var firstValue in firstUser) {
          if ( secondUser.ContainsKey(firstValue.Key) == true) {
            firstResult.Add(firstValue.Key, firstValue.Value);
            secondResult.Add(firstValue.Key, secondUser[firstValue.Key]);

          }
        }

        result.Add(keyX, firstResult);
        result.Add(keyY, secondResult);

      } else {

        var firstResult = new Dictionary<int, double>();
        var secondResult = new Dictionary<int, double>();
        var keysChecked = new List<int>();

        foreach (var firstValue in firstUser) {
          firstResult.Add(firstValue.Key, firstValue.Value);
          keysChecked.Add(firstValue.Key);
          if (secondUser.ContainsKey(firstValue.Key) == true) {
            secondResult.Add(firstValue.Key, secondUser[firstValue.Key]);
          } else {
            secondResult.Add(firstValue.Key, 0);
          }
        }
        foreach (var secondValue in secondUser) {
          if (keysChecked.Contains(secondValue.Key) == false) {
            firstResult.Add(secondValue.Key, 0);
            secondResult.Add(secondValue.Key, secondValue.Value);
          }
        }

        result.Add(keyX, firstResult);
        result.Add(keyY, secondResult);
      }

      return result;

    }

    public static Tuple<
      Dictionary<int, double>,
      Dictionary<int, double>>
      splitDictionaries (Dictionary<int,Dictionary<int, double>> data) {
      //Acting under the pretense that every dataset this method gets
      //Has gone through the datafilter in DataParser
      //So we know it always has a matched pair of keys
      //And 2 comparees
        int n = 0;
        var firstItem = new Dictionary<int, double>();
        var secondItem = new Dictionary<int, double>();
        
        foreach (var dataItem in data) {
          //Console.WriteLine(dataItem.Key);
          if (n == 0) {
            firstItem = data[dataItem.Key];
          } else {
            secondItem = data[dataItem.Key];
          }
          n += 1;
        }

        return new Tuple<Dictionary<int, double>, Dictionary<int, double>>(firstItem, secondItem);
    }
  }
}
