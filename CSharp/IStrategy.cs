using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
  interface IStrategy {
     double algorithm(Tuple<Dictionary<int, float>, Dictionary<int,float>> data);
  }
}
