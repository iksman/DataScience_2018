using System;
using System.Collections.Generic;

namespace Period_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser("./WineData.csv");
            KMeans kmeans = new KMeans(5, 32);
            foreach (Centroid centroid in kmeans.centroids){
                foreach (double coordinate in centroid.coordinate){
                    Console.WriteLine(kmeans.centroids.IndexOf(centroid).ToString() + " - " + coordinate.ToString());
                }
            }
        }
    }
}
