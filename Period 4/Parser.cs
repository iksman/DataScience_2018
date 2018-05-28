using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Period_4{
  class Parser{
    public List<string> file;
    public List<List<double>> parsedContent;

    public Parser(string url){
      this.file = new List<string>();
      this.parsedContent = new List<List<double>>();
      try{
        foreach(string line in File.ReadAllLines(url)){
          this.file.Add(line);
        }
        this.parsedContent = this.parseContents();
      }catch(Exception e){
        throw e;
      }
    }

    private List<List<double>> parseContents(){
      List<double> product = new List<double>();
      List<List<double>> productList = new List<List<double>>();

      //file.Aggregate((x) => x.Aggregate((y) => y.Split(",")));
      foreach(string line in file){
        foreach(string number in line.Split(",")){
          product.Add(int.Parse(number));
        }
        productList.Add(product);
        product = new List<double>();
      }
      
      //Flip array to be client horizontal
      List<double> client = new List<double>();
      List<List<double>> clientList = new List<List<double>>();
      for (int i = 0; i < productList[0].Count; i++){
        foreach (List<double> productIterator in productList){
          client.Add(productIterator[i]);
        }
        clientList.Add(client);
        client = new List<double>();
      }
      return clientList;
    }

    
  }

}