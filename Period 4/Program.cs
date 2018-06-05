using System;
using System.Collections.Generic;

namespace Period_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int max = 100;
            for (int i = 2; i < max + 1; i++){
                Parser parser = new Parser("./WineData.csv");
                KMeans kmeans = new KMeans();
                List<Cluster> clusteredResult = kmeans.mainLoop(i, 10, parser.ParsedContent);

                //foreach (Cluster cluster in clusteredResult){
                //    Console.Write((cluster.Id + 1).ToString() + " - " + cluster.Points.Count.ToString() + " : ");
                //    foreach (var point in cluster.Points){
                //       Console.Write(point.Id.ToString() + ", ");
                //    }
                //    Console.WriteLine();
                //}

                Console.WriteLine("SSE with " + i.ToString() + " centroid(s): " + SSE.CalculateSSE(clusteredResult).ToString());
            }
        }
    }
}
