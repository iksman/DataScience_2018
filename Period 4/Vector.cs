using System;
using System.Linq;
using System.Collections.Generic;

namespace Period_4{
    class Vector{
        public List<double> Coordinates {get; set;}
        public double Distance {get; set;}

        public Vector(){
            Coordinates = new List<double>();
            
        }

        public Vector(List<double> coordinates){
            Coordinates = coordinates;
        }
    }
}