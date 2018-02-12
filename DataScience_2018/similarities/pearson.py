import math

class Pearson:
  def strategy(self,p,q):
    return self.differences(p,q)

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
