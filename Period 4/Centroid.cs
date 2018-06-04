using System;
using System.Collections.Generic;

namespace Period_4{
    
    class Statics{
        public Statics(){}
        //Completely random
        public static List<Vector> InitCentroids (int centroidCount, int dimension){
            List<Vector> centroids = new List<Vector>();
            Random rnd = new Random();
            for (int i = 0; i < centroidCount; i++){
                List<double> coordinate = new List<double>();
                for (int j = 0; j < dimension; j++){
                    coordinate.Add(rnd.NextDouble());
                }
                centroids.Add(new Vector(coordinate));
                coordinate = new List<double>();
            }
            return centroids;
        }

        public static List<Vector> InitCentroidsMark (int centroidCount, List<Vector> data){
            List<Vector> centroids = new List<Vector>();
            Random rnd = new Random();
            for(var j = 0; j < centroidCount; j++){                    
                int UserId = rnd.Next(0, 100);
                if(!centroids.Contains(data[UserId])){
                    centroids.Add(data[UserId]);
                } else {
                    centroidCount++;
                }
            }


            return centroids;
        }

        public static List<Cluster> InitCluster (int centroidCount, List<Vector> centroids=null){
            var clusters = new List<Cluster>();
            if (centroids != null){
                for(var i = 0; i < centroidCount; i++){
                    clusters.Add(new Cluster(i, centroids[i]));
                }
            }else{
                for(var i = 0; i < centroidCount; i++){
                    clusters.Add(new Cluster(i));
                }
            }
            return clusters;            
        }
    }

    //class Centroid{
    //    public Vector vector {get; set; }
    //    public Centroid(Vector vector){
    //        this.vector = vector;
    //    }
    //}
}