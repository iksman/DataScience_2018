using System;

namespace Period_4
{
    static class Euclidean
    {
        public static double GetDistance(Vector user1, Vector user2){
            
            double result = 0;

            for (int i = 0; i < user1.Coordinates.Count; i++)
            {
                result += Math.Pow((user1.Coordinates[i] - user2.Coordinates[i]),2);
            }

            result = 1 / (1 + Math.Sqrt(result));

            return result;
        }
    }
}