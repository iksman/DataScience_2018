using System;
using System.Collections.Generic;

namespace Period_4
{
    class Cluster
    {
        public int Id { get; set; }
        public Vector Centroid { get; set; }
        public List<Vector> Points { get; set; }

        public Cluster(int id)
        {
            Id = id;
            Centroid = new Vector();
            Points = new List<Vector>();
        }

        public Cluster(int id, Vector centroid)
        {
            Id = id;
            Centroid = centroid;
            Points = new List<Vector>();

        }

        public Cluster(int id, Vector centroid, List<Vector> points)
        {
            Id = id;
            Centroid = centroid;
            Points = points;

        }

        public Cluster Clone()
        {
            return new Cluster(this.Id, this.Centroid, this.Points);
        }
    }
}