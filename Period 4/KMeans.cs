using System;
using System.Collections.Generic;
using System.Linq;

namespace Period_4{
    class Centroid{
        public List<double> coordinate;
        public Centroid(List<double> coordinate){
            this.coordinate = coordinate;
        }
    }

    class KMeans{
        public List<Centroid> centroids;

        public KMeans(int centroidCount, int dimension){
            centroids = new List<Centroid>();
            var rnd = new Random();
            for (int i = 0; i < centroidCount; i++){
                List<double> coordinate = new List<double>();
                for (int j = 0; j < dimension; j++){
                    coordinate.Add(rnd.Next(0,2));
                }
                centroids.Add(new Centroid(coordinate));
                coordinate = new List<double>();
            }
        }
    }
}