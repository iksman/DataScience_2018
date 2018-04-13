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

    public static Dictionary<int,Dictionary<int,float>> write2DArray(string filename, string split) {
      string[] data = writeArray(filename);
      var result = new Dictionary<int,Dictionary<int,float>>();
      Dictionary<int,float> score;

      foreach (string line in data) {
        string[] lineResult = line.Split(split);
        score = new Dictionary<int, float>();
        score.Add(int.Parse(lineResult[1]),  float.Parse(lineResult[2]));

        if ( result.TryAdd( int.Parse(lineResult[0]), score)) {
        } else {
          result[int.Parse(lineResult[0])].Add(int.Parse(lineResult[1]), float.Parse(lineResult[2]));
        }
      }

      return result;
    }



    public static Dictionary<int,Dictionary<int,float>> write2DArray_MovieLens(string filename) { 
      string[] data = writeArray(filename).Skip(1).ToArray(); //Skip first item because first line is definition as it is a csv.
      var result = new Dictionary<int, Dictionary<int,float>>();
      
      foreach (string line in data) {
        string[] lineResult = line.Split(',');
        Dictionary<int,float> score = new Dictionary<int, float>();
        score.Add(int.Parse(lineResult[1]), float.Parse(lineResult[2]));

        if (result.TryAdd(int.Parse(lineResult[0]), score)) { 
        } else {
          result[int.Parse(lineResult[0])].Add(int.Parse(lineResult[1]), float.Parse(lineResult[2]));
        }
      }
      return result;
    }

    public static List<int> getProducts(Dictionary<int, Dictionary<int,float>> data) {
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

    public static Dictionary<int, Dictionary<int, float>> filterRatings(Dictionary<int, Dictionary<int, float>> data, int productId) {
      Dictionary<int, Dictionary<int, float>> result = new Dictionary<int, Dictionary<int, float>>();
      foreach (var user in data) {
        if (user.Value.ContainsKey(productId)) {
          result.Add(user.Key, user.Value);
        }
      }
      return result;
    }
    
    public static Dictionary<int, Dictionary<int, float>> filterTwoProducts(Dictionary<int, Dictionary<int, float>> data, int productId1, int productId2) {
      Dictionary<int, Dictionary<int, float>> result = new Dictionary<int, Dictionary<int, float>>();
      foreach (var user in data) {
        if (user.Value.ContainsKey(productId1) && user.Value.ContainsKey(productId2)) {
          result.Add(user.Key, user.Value);
        }
      }
      return result;
    }

    public static Dictionary<int, Dictionary<int,float>> filterRatings(Dictionary<int, Dictionary<int, float>> data, int productId, int target) {
      Dictionary<int, Dictionary<int,float>> result = new Dictionary<int, Dictionary<int, float>>();
      foreach (var user in data) {
        if (user.Key == target) {
          result.Add(user.Key, user.Value);
        }else if (user.Value.ContainsKey(productId)) {
          result.Add(user.Key, user.Value);
        }
      }
      return result;
    }

    public static void checkData(Dictionary<int, Dictionary<int, float>> data) {
    }

    public static Dictionary<int,Dictionary<int,float>> filterData(Dictionary<int,Dictionary<int,float>> data, int keyX, int keyY, bool delete=true) {
      var firstUser = data[keyX];
      var secondUser = data[keyY];
      
      var result = new Dictionary<int, Dictionary<int, float>>();
      
      if (delete == true) {

        var firstResult = new Dictionary<int, float>();
        var secondResult = new Dictionary<int, float>();

        foreach (var firstValue in firstUser) {
          if ( secondUser.ContainsKey(firstValue.Key) == true) {
            firstResult.Add(firstValue.Key, firstValue.Value);
            secondResult.Add(firstValue.Key, secondUser[firstValue.Key]);

          }
        }

        result.Add(keyX, firstResult);
        result.Add(keyY, secondResult);

      } else {

        var firstResult = new Dictionary<int,float>();
        var secondResult = new Dictionary<int,float>();
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
      Dictionary<int,float>,
      Dictionary<int,float>>
      splitDictionaries (Dictionary<int,Dictionary<int,float>> data) {
      //Acting under the pretense that every dataset this method gets
      //Has gone through the datafilter in DataParser
      //So we know it always has a matched pair of keys
      //And 2 comparees
        int n = 0;
        var firstItem = new Dictionary<int, float>();
        var secondItem = new Dictionary<int, float>();
        
        foreach (var dataItem in data) {
          //Console.WriteLine(dataItem.Key);
          if (n == 0) {
            firstItem = data[dataItem.Key];
          } else {
            secondItem = data[dataItem.Key];
          }
          n += 1;
        }

        return new Tuple<Dictionary<int, float>, Dictionary<int, float>>(firstItem, secondItem);
    }
  }
}
