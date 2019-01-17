from sklearn.neural_network import MLPRegressor
from math import sin
import numpy as np

n = 360 * 5
n += 1

X = np.zeros((n, 1), dtype=np.float32)

for i in range(n):
    X[i][0] = i

Y = [i * 5 for i in X.ravel()]

#for i in range(n):
#    print("%.1f, %.4f" % (X[i][0], Y[i]))

clf = MLPRegressor(activation='identity', solver='lbfgs', alpha=1e-5,
                    hidden_layer_sizes=(5, 2), random_state=1)

clf.fit(X, Y)

#result_proba = clf.predict([[2., 2.], [1., 2.]])
result = clf.predict([[45]])
print(result)
