class Manhattan:
  def strategy(self,p,q):
    return (1 / (self.differences(p,q) + 1) )

  def differences(self,p,q):
    totalSum = n = 0
    for item in p:
      if len(q) >= (n + 1):
        n += 1
        totalSum += abs(item - q[n - 1])
    return totalSum