using System;
using System.Collections.Generic;
using System.Linq;

namespace Period_4{
    class KMeans{
        public KMeans(){
        }

        public List<Cluster> mainLoop(int centroidCount, int iterations, List<Vector> data){
            List<Cluster> clusters = Statics.InitCluster(centroidCount, Statics.InitCentroids(centroidCount, data[0].Coordinates.Count));
            int currentIterations = 0;
            
            while (currentIterations != iterations){
                //Having a hard time dividing the classes from their refference to extract only their content
                //So that the OldCluster class isn't affected when the new cluster gets altered
                List<int> count = new List<int>();
                foreach (Cluster cluster in clusters){
                    count.Add(cluster.Points.Count);
                }
                step(data, clusters);
                if (clusters.Select(c => c.Points.Count).ToList().SequenceEqual(count)){
                    currentIterations++;
                }                
            }
            
            return clusters;
        }

        public List<Cluster> step (List<Vector> data, List<Cluster> clusters){
            foreach (Cluster cluster in clusters){
                cluster.Points.Clear();
            }
            
            foreach (Vector point in data){
                List<Tuple<int,double>> distances = new List<Tuple<int,double>>();
                foreach (Cluster cluster in clusters){
                    distances.Add(new Tuple<int, double>(cluster.Id, Euclidean.GetDistance(point, cluster.Centroid)));
                }
                int bestClusterId = distances.OrderByDescending(d => d.Item2).First().Item1;
                clusters.First(c => c.Id == bestClusterId).Points.Add(point);
            }

            int dimensions = data[0].Coordinates.Count;
            foreach (Cluster cluster in clusters){
                Dictionary<int,double> averages = new Dictionary<int,double>();
                for (int i=0; i < dimensions; i++){
                    double sum = 0;
                    for (int j=0; j < cluster.Points.Count; j++){
                        sum += cluster.Points[j].Coordinates[i];
                    }
                    averages.Add(i, (sum/dimensions));
                }

                foreach (KeyValuePair<int,double> average in averages){
                    cluster.Centroid.Coordinates[average.Key] = average.Value;
                }
                //}
            }

            return clusters;
        }
    }
}