import numpy as np
from sklearn import tree
import matplotlib.pyplot as plt

rng = np.random.RandomState(42)
x = np.sort(5 * rng.rand(100, 1), axis=0)
y = np.sin(x).ravel()
#y[::2] += 0.5 * (0.5 - rng.rand(50))

regr1 = tree.DecisionTreeRegressor(max_depth=2, random_state=42)
regr1.fit(x, y)

regr2 = tree.DecisionTreeRegressor(max_depth=5, random_state=42)
regr2.fit(x, y)

x_test = np.arange(0.0, 5.0, 0.01)[:, np.newaxis]
y_1 = regr1.predict(x_test)
y_2 = regr2.predict(x_test)

plt.style.use('ggplot')
plt.scatter(x, y, c='k', s=50, label='data')
plt.plot(x_test, y_1, label="max_depth=2", linewidth=5)
plt.plot(x_test, y_2, label="max_depth=5", linewidth=5)
plt.xlabel("data")
plt.ylabel("target")
plt.legend()
plt.show()