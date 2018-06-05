using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Period_4{
  class Parser{
    //public List<string> Content {get; set;}
    public List<Vector> ParsedContent {get; set;}

    public Parser(string url){
      List<Vector> result = new List<Vector>();

      List<List<double>> content = File.ReadAllLines(url)
        .Select(l =>
          l.Split(",")
            .Select(i => double.Parse(i))
              .ToList())
                .ToList();
      
      //Content is als het goed is nu een lijst van producten 
      //this.ParsedContent = this.parseContents(content);

      Dictionary<int, Vector> intermediateResult = new Dictionary<int, Vector>();
      for (int i = 0; i < content[0].Count; i++){
        foreach (List<double> coordinates in content){
          if (intermediateResult.ContainsKey(i)){
            intermediateResult[i].Coordinates.Add(coordinates[i]);
          }else{
            intermediateResult.Add(i, new Vector(coordinates[i], i));
          }          
        }
      }

      //Colapse dict into list
      foreach (var item in intermediateResult.OrderBy(i => i.Key)){
        result.Add(item.Value);
      }

      this.ParsedContent = result;
    }    
  }
}