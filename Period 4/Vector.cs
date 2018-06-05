using System;
using System.Linq;
using System.Collections.Generic;

namespace Period_4{
    class Vector{
        public List<double> Coordinates {get; set;}
        public double Distance {get; set;}
        public int Id {get; set; }

        public Vector(){
            Coordinates = new List<double>();
            Id = -1;
        }

        public Vector(List<double> coordinates){
            Coordinates = coordinates;
            Id = -1;
        }

        public Vector(List<double> coordinates, int id){
            Coordinates = coordinates;
            Id = id;
        }

        public Vector(double coordinate, int id){
            Coordinates = new List<double>();
            Coordinates.Add(coordinate);
            Id = id;
        }
    }
}