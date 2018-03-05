using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
  class ConcreteStrategy1 : IStrategy
  {
    public double algorithm() {
      return 2.0;
    }
  }
}
