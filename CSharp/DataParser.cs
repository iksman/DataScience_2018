using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
  class DataParser
  {
    public string[] writeArray(string filename) {
      return System.IO.File.ReadAllLines(filename);
    }
    public Dictionary<int,Dictionary<int,float>> write2DArray(string filename, string split) {
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
  }
}
