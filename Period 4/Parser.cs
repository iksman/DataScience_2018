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

      for (int i = 0; i < content[0].Count; i++){
        List<double> coordinates = new List<double>();
        foreach(List<double> product in content){
          coordinates.Add(product[i]);
        }
        result.Add(new Vector(coordinates));
      }
      this.ParsedContent = result;
    }    
  }
}