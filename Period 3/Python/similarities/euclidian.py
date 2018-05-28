import math
class Euclidian:
  def strategy(self,p,q):
    rmZ = self.removeZeroes(p,q)
    return (1 / (self.differences(rmZ[0],rmZ[1]) + 1) )

  def differences(self,p,q):
    totalSum = n = 0
    for item in p:
      if len(q) >= (n + 1):
        n += 1
        totalSum += math.pow((item - q[n-1]),2)
    return math.sqrt(totalSum)

  def removeZeroes(self,p,q):
    n = 0
    modifiedP = []
    modifiedQ = []
    for item in p:
      n+= 1
      if (type(item) == type(q[n - 1])) and (item != None) and (q[n-1] !=  None):
        if (item > 0 and q[n-1] > 0):
          modifiedP += [item]
          modifiedQ += [q[n-1]]
    return [modifiedP, modifiedQ]