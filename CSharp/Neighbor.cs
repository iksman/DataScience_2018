using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Neighbor {
        public int userId;
        public double similarity;
        public Dictionary<int,float> review;

        public Neighbor(int userId, double similarity, Dictionary<int,float> review) {
            this.userId = userId;
            this.similarity = similarity;
            this.review = review;
        }
    }
}
