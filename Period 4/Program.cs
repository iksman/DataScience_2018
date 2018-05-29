using System;
using System.Collections.Generic;

namespace Period_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser("./WineData.csv");
            KMeans kmeans = new KMeans();
            List<Cluster> clusteredResult = kmeans.mainLoop(5, 50, parser.ParsedContent);

            foreach (Cluster cluster in clusteredResult){
                Console.WriteLine(clusteredResult.IndexOf(cluster).ToString() + " - " + cluster.Points.Count);
            }



            //foreach (Centroid centroid in kmeans.centroids){
            //    Console.Write(kmeans.centroids.IndexOf(centroid).ToString() + " - " + centroid.coordinate.Count.ToString() + " - ");
            //    foreach (double coordinate in centroid.coordinate){
            //        Console.Write(coordinate.ToString() + " ");
            //    }
            //    Console.WriteLine();                
            //}

            // foreach (Vector vector in parser.ParsedContent){
            //     Console.Write(parser.ParsedContent.IndexOf(vector).ToString() + " - ");
            //     foreach (double coordinate in vector.Coordinates){
            //         Console.Write(coordinate.ToString() + " ");
            //     }
            //     Console.WriteLine();
            // }
        }
    }
}
