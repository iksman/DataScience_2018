using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
  class DataParser
  {
    public static string[] writeArray(string filename) {
      return System.IO.File.ReadAllLines(filename);
    }

    public static Dictionary<int,Dictionary<int,float>> write2DArray(string filename, string split) {
      string[] test = writeArray(filename);
      var result = new Dictionary<int,Dictionary<int,float>>();
      Dictionary<int,float> score;

      foreach (string line in test) {
        string[] lineResult = line.Split(split);
        score = new Dictionary<int, float>();
        score.Add(  int.Parse(lineResult[1]),  float.Parse(lineResult[2])  );

        if ( result.TryAdd( int.Parse(lineResult[0]), score)) {} else {
          result[int.Parse(lineResult[0])].Add(int.Parse(lineResult[1]), float.Parse(lineResult[2]));
        }

        //result.Add(  int.Parse(lineResult[0]),  score  );
      }

      return result;
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
