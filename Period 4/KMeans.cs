using System;
using System.Collections.Generic;
using System.Linq;

namespace Period_4{
    



    class KMeans{
        public KMeans(){
        }

        //Moet geen bool zijn
        public List<Cluster> step(int centroidCount, int iterations, List<Vector> data, List<Cluster> clusters=null){
            // TODO: verander type
            if (iterations != 0){
                if (clusters == null){
                    //Eerste iteratie
                    clusters = Statics.InitCluster(centroidCount, Statics.InitCentroids(centroidCount, data[0].Coordinates.Count));
                    Console.WriteLine();
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
                    step(centroidCount, iterations - 1, data, newClusters);
                }else{               
                    step(centroidCount, iterations, data, newClusters);
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