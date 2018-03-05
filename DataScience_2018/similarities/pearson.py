import math

class Pearson:
  def strategy(self,p,q):
    rmZ = self.removeZeroes(p,q)

    return self.differences(rmZ[0],rmZ[1])

  def differences(self,p,q):
    a = b = c = n = x = y = 0

    for item in p:
      if len(q) >= (n + 1):
        n += 1

        x += item
        y += q[n-1]

        a += (item * q[p.index(item)])
        b += math.pow(item,2)
        c += math.pow(q[p.index(item)],2)

      topPart = (a - ((x * y) / n))
      bottomLeftPart = math.sqrt(b - (math.pow(x,2) / n))
      bottomRightPart = math.sqrt(c - (math.pow(y,2) / n))
      bottomPart = bottomLeftPart * bottomRightPart
      

    return topPart / bottomPart

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
