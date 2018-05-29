using System;
using System.Collections.Generic;
using System.Linq;

namespace Period_4{
    



    class KMeans{
        public KMeans(){
        }

        public List<Cluster> mainLoop(int centroidCount, int iterations, List<Vector> data){
            List<Cluster> clusters = Statics.InitCluster(centroidCount, Statics.InitCentroids(centroidCount, data[0].Coordinates.Count));
            List<Cluster> newClusters = new List<Cluster>();
            int currentIteration = 0;
            while(currentIteration != iterations){
                newClusters = this.step(centroidCount, data, clusters);

                var debug = clusters.Select(c => c.Points.Count).ToList();
                var debug1 = newClusters.Select(nc => nc.Points.Count).ToList();

                if (debug.SequenceEqual(debug1)){
                    currentIteration++;
                }else{               
                    Console.WriteLine(currentIteration.ToString());
                }
                clusters = newClusters;
            }
            return newClusters;

        }

        public List<Cluster> step(int centroidCount, List<Vector> data, List<Cluster> clusters){

            //Main loop
            var newClusters = Statics.InitCluster(centroidCount);
            foreach (Cluster cluster in clusters){
                newClusters[clusters.IndexOf(cluster)].Centroid = cluster.Centroid;
            }
            
            foreach(var point in data){
                var distances = new List<Tuple<int,double>>();
                foreach(var cluster in clusters){
                    distances.Add(new Tuple<int,double>(cluster.Id, Euclidean.GetDistance(point, cluster.Centroid)));
                }
                var bestCluster = distances.OrderByDescending(c => c.Item2).First();
                newClusters.First(i => i.Id == bestCluster.Item1).Points.Add(point);
            }

            //Result Cluster reworken

            var dimension = data[0].Coordinates.Count;
            foreach(var cluster in clusters){
                //var newCentroid = new Vector();
                for(int i = 0; i < dimension; i++){
                    double sum = 0;
                    for(int j = 0; j < cluster.Points.Count; j++){
                        sum += cluster.Points[j].Coordinates[i];
                    }
                    //newCentroid.Coordinates.Add(sum / dimension);
                    if (sum != 0){
                        newClusters.Where(nc => nc.Id == cluster.Id).First().Centroid.Coordinates[i] = (sum / dimension);
                    }
                }
                //newClusters.Where(nc => nc.Id == cluster.Id).First().Centroid = newCentroid;
            }
            //Make centroidCount amount of clusters
            //Hier gaat ie werkelijkwaar nooit komen maar fuck you Csharp linting voor dit requiren.
            return newClusters;
        } 

        public List<Cluster> recursiveStep(int centroidCount, int iterations, List<Vector> data, List<Cluster> clusters=null){
            if (iterations != 0){
                if (clusters == null){
                    //Eerste iteratie
                    clusters = Statics.InitCluster(centroidCount, Statics.InitCentroids(centroidCount, data[0].Coordinates.Count));
                }else{
                    //Tweede+ iteratie

                    var dimension = data[0].Coordinates.Count;
                    foreach(var cluster in clusters){
                        var newCentroid = new Vector();
                        for(int i = 0; i < dimension; i++){
                            double sum = 0;
                            for(int j = 0; j < cluster.Points.Count; j++){
                                sum += cluster.Points[j].Coordinates[i];
                            }
                            newCentroid.Coordinates.Add(sum / dimension);
                        }
                        cluster.Centroid = newCentroid;
                    }
                }

                //Main loop
                var newClusters = Statics.InitCluster(centroidCount);
                foreach(var point in data){
                    var distances = new List<Tuple<int,double>>();
                    foreach(var cluster in clusters){
                        distances.Add(new Tuple<int,double>(cluster.Id, Euclidean.GetDistance(point, cluster.Centroid)));
                    }
                    var bestCluster = distances.OrderByDescending(c => c.Item2).First();
                    newClusters.First(i => i.Id == bestCluster.Item1).Points.Add(point);
                }  

                var debug = clusters.Select(c => c.Points.Count).ToList();
                var debug1 = newClusters.Select(nc => nc.Points.Count).ToList();

                if (debug.SequenceEqual(debug1)){
                    recursiveStep(centroidCount, iterations - 1, data, newClusters);
                }else{               
                    recursiveStep(centroidCount, iterations, data, newClusters);
                }
                //Make centroidCount amount of clusters
            }else{
                //Iterations == 0
                return clusters;
            }
            //Hier gaat ie werkelijkwaar nooit komen maar fuck you Csharp linting voor dit requiren.
            return clusters;
        }        
    }
}