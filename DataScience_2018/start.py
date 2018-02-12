from similarities import manhattan, euclidian, pearson, strategies

strats = strategies.RecommendationStrategy()
manh = manhattan.Manhattan()
eucl = euclidian.Euclidian()
pear = pearson.Pearson()

dataset1 = [5,-1,1,3,5]
dataset2 = [2,5,4,3,None]

##########################################

print(strats.calculate(manh,dataset1,dataset2))
print(strats.calculate(eucl,dataset1,dataset2))
print(strats.calculate(pear,dataset1,dataset2))
