class RecommendationStrategy:

  def calculate(self,strategy,p,q):
    try:
      n = 0
      modifiedP = []
      modifiedQ = []
      for item in p:
        if len(q) >= (n + 1):
          n += 1
          if (item != None):
            if (item < 0):
              modifiedP += [0]
            else:
              modifiedP += [item]
          else:
            modifiedP += [0]

          if (q[n-1] != None):
            if (q[n-1] < 0):
              modifiedQ += [0]
            else:
              modifiedQ += [q[n-1]]
          else:
            modifiedQ += [0]
          #if (type(item) == type(q[n - 1])) and (item != None) and (q[n-1] !=  None):
          #  if (item >= 0 and q[n-1] >= 0):
          #    modifiedP += [item]
          #    modifiedQ += [q[n-1]]
          #  elif (item < 0 and q[n-1] < 0):
          #    modifiedP
              

      #print(modifiedP)
      return strategy.strategy(modifiedP,modifiedQ)
    except:
      return "Interface not implemented properly"
