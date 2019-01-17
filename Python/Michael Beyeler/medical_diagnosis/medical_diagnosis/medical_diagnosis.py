import matplotlib.pyplot as plt
import numpy as np
from sklearn.feature_extraction import DictVectorizer
import sklearn.model_selection as ms
import cv2
from sklearn import metrics, tree
from sklearn.externals.six import StringIO
import pydot

data = [
    {'age': 33, 'sex': 'F', 'BP': 'high', 'cholesterol': 'high',
     'Na': 0.66, 'K': 0.06, 'drug': 'A'},
    {'age': 77, 'sex': 'F', 'BP': 'high', 'cholesterol': 'normal',
     'Na': 0.19, 'K': 0.03, 'drug': 'D'},
    {'age': 88, 'sex': 'M', 'BP': 'normal', 'cholesterol': 'normal',
     'Na': 0.80, 'K': 0.05, 'drug': 'B'},
    {'age': 39, 'sex': 'F', 'BP': 'low', 'cholesterol': 'normal',
     'Na': 0.19, 'K': 0.02, 'drug': 'C'},
    {'age': 43, 'sex': 'M', 'BP': 'normal', 'cholesterol': 'normal',
     'Na': 0.36, 'K': 0.03, 'drug': 'D'},
    {'age': 82, 'sex': 'F', 'BP': 'normal', 'cholesterol': 'normal',
     'Na': 0.09, 'K': 0.09, 'drug': 'C'},
    {'age': 40, 'sex': 'M', 'BP': 'high', 'cholesterol': 'normal',
     'Na': 0.89, 'K': 0.02, 'drug': 'A'},
    {'age': 88, 'sex': 'M', 'BP': 'normal', 'cholesterol': 'normal',
     'Na': 0.80, 'K': 0.05, 'drug': 'B'},
    {'age': 29, 'sex': 'F', 'BP': 'high', 'cholesterol': 'normal',
     'Na': 0.35, 'K': 0.04, 'drug': 'D'},
    {'age': 53, 'sex': 'F', 'BP': 'low', 'cholesterol': 'normal',
     'Na': 0.54, 'K': 0.06, 'drug': 'C'},
    {'age': 63, 'sex': 'M', 'BP': 'low', 'cholesterol': 'high',
     'Na': 0.86, 'K': 0.09, 'drug': 'B'},
    {'age': 60, 'sex': 'M', 'BP': 'low', 'cholesterol': 'normal',
     'Na': 0.66, 'K': 0.04, 'drug': 'C'},
    {'age': 55, 'sex': 'M', 'BP': 'high', 'cholesterol': 'high',
     'Na': 0.82, 'K': 0.04, 'drug': 'B'},
    {'age': 35, 'sex': 'F', 'BP': 'normal', 'cholesterol': 'high',
     'Na': 0.27, 'K': 0.03, 'drug': 'D'},
    {'age': 23, 'sex': 'F', 'BP': 'high', 'cholesterol': 'high',
     'Na': 0.55, 'K': 0.08, 'drug': 'A'},
    {'age': 49, 'sex': 'F', 'BP': 'low', 'cholesterol': 'normal',
     'Na': 0.27, 'K': 0.05, 'drug': 'C'},
    {'age': 27, 'sex': 'M', 'BP': 'normal', 'cholesterol': 'normal',
     'Na': 0.77, 'K': 0.02, 'drug': 'B'},
    {'age': 51, 'sex': 'F', 'BP': 'low', 'cholesterol': 'high',
     'Na': 0.20, 'K': 0.02, 'drug': 'D'},
    {'age': 38, 'sex': 'M', 'BP': 'high', 'cholesterol': 'normal',
     'Na': 0.78, 'K': 0.05, 'drug': 'A'},
     ]

target = [ d[ 'drug' ] for d in data ]
[d.pop('drug') for d in data]
plt.style.use('ggplot')
age = [d['age'] for d in data]
sodium = [d['Na'] for d in data]
potassium = [d['K'] for d in data]
print(target)

target = [ord(t) - 65 for t in target]
vec = DictVectorizer(sparse = False)
data_pre = vec.fit_transform(data)
#print(vec.get_feature_names())
#print(data_pre[0])
data_pre = np.array(data_pre, dtype=np.float32)
target = np.array(target, dtype=np.float32)

x_train, x_test, y_train, y_test = ms.train_test_split(data_pre, target, test_size=5, random_state = 42)
#dtree = cv2.ml.dtree_create()
#dtree.train(x_train, cv2.ml.ROW_SAMPLE, y_train)
#y_pre = dtree.predict(x_test)
#accuracy = metrics.accuracy_score(y_test, dtree.predict(x_test))
#print(accuracy)

dtc = tree.DecisionTreeClassifier()
dtc.fit(x_train, y_train)
train_score = dtc.score(x_train, y_train)
test_score = dtc.score(x_test, y_test)

print(train_score)
print(test_score)

tree.export_graphviz(dtc,out_file='tree.dot')

#plt.scatter(sodium, potassium)
#plt.xlabel('sodium')
#plt.ylabel('potassium')
#plt.show()