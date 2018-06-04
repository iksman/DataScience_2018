using System;
using System.Collections.Generic;
using System.Linq;

namespace Period_4{
    class SSE{
        public SSE(){
        }

        public static double CalculateSSE(List<Cluster> clusters){
            return clusters.Select(c => c.Points.Select(p => Math.Pow(p.Distance,2)).Sum()).Average();//( clusters.Select(c => c.Points.Count).Sum() )- result;
        }
    }
}