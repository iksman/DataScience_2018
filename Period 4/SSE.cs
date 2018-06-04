using System;
using System.Collections.Generic;
using System.Linq;

namespace Period_4{
    class SSE{
        public SSE(){
        }

        public static double CalculateSSE(List<Cluster> clusters){
            double result = 0;
            foreach (Cluster cluster in clusters){
                if (cluster.Points.Count != 0){
                    result += cluster.Points.Select(p => 
                        // Math.Pow(
                        //     Euclidean.GetDistance(p, cluster.Centroid),
                        //     2
                        // )
                        Math.Pow(p.Distance,2)
                    ).Sum();
                }
            }


            return result;//( clusters.Select(c => c.Points.Count).Sum() )- result;
        }
    }
}