using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Neighbor {
        public int userId;
        public double similarity;

        public Neighbor(int userId, double similarity) {
            this.userId = userId;
            this.similarity = similarity;
        }
    }
}
