# MNIST Digit Prediction with k-Nearest Neighbors
#-----------------------------------------------
#
# This script will load the MNIST data, and split
# it into test/train and perform prediction with
# nearest neighbors
#
# For each test integer, we will return the
# closest image/integer.
#
# Integer images are represented as 28x8 matrices
# of floating point numbers

import cv2
import random
import numpy as np
import tensorflow as tf
import matplotlib.pyplot as plt
from PIL import Image
from tensorflow.examples.tutorials.mnist import input_data
from tensorflow.python.framework import ops
ops.reset_default_graph()

def inside(r1, r2):
  x1,y1,w1,h1 = r1
  x2,y2,w2,h2 = r2
  if (x1 > x2) and (y1 > y2) and (x1+w1 < x2+w2) and (y1+h1 < y2 + h2):
    return True
  else:
    return False

def wrap_digit(rect):
  x, y, w, h = rect
  padding = 5
  hcenter = x + w/2
  vcenter = y + h/2
  if (h > w):
    w = h
    x = hcenter - (w/2)
  else:
    h = w
    y = vcenter - (h/2)
  return (x-padding, y-padding, w+padding, h+padding)

font = cv2.FONT_HERSHEY_SIMPLEX

path = "numbers.png"
img = cv2.imread(path, cv2.IMREAD_UNCHANGED)
bw = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
bw = cv2.GaussianBlur(bw, (7,7), 0)
ret, thbw = cv2.threshold(bw, 200, 255, cv2.THRESH_BINARY_INV)
thbw = cv2.erode(thbw, np.ones((1,1), np.uint8), iterations = 2)
image, cntrs, hier = cv2.findContours(thbw.copy(), cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)

rectangles = []

for c in cntrs:
  r = x,y,w,h = cv2.boundingRect(c)
  a = cv2.contourArea(c)
  b = (img.shape[0]-3) * (img.shape[1] - 3)

  is_inside = False
  for q in rectangles:
    if inside(r, q):
      is_inside = True
      break
  if not is_inside:
    if not a == b:
      rectangles.append(r)
     
x_vals_test = np.zeros( (len(rectangles), 784) )
i = 0

for r in rectangles:
  x,y,w,h = wrap_digit(r) 
  cv2.rectangle(img, (int(x),int(y)), (int(x+w), int(y+h)), (0, 255, 0), 2)
  roi = thbw[int(y):int(y+h), int(x):int(x+w)]
  res = cv2.resize(roi, (28, 28))
  x_vals_test[i] = res.ravel()
  i += 1

# Create graph
sess = tf.Session()

# Load the data
mnist = input_data.read_data_sets("MNIST_data", one_hot=True)

# Random sample
train_size = len(mnist.train.images)
rand_train_indices = np.random.choice(len(mnist.train.images), train_size, replace=False)
x_vals_train = mnist.train.images[rand_train_indices]
y_vals_train = mnist.train.labels[rand_train_indices]
print(y_vals_train.shape)
print(x_vals_train.shape)
print(x_vals_test.shape)

#cv2.waitKey(0)
# Declare k-value and batch size
k = 4

# Placeholders
x_data_train = tf.placeholder(shape=[None, 784], dtype=tf.float32)
x_data_test = tf.placeholder(shape=[None, 784], dtype=tf.float32)
y_target_train = tf.placeholder(shape=[None, 10], dtype=tf.float32)
#y_target_test = tf.placeholder(shape=[None, 10], dtype=tf.float32)

# Declare distance metric
# L1
distance = tf.reduce_sum(tf.abs(tf.subtract(x_data_train, tf.expand_dims(x_data_test,1))), reduction_indices=2)

# L2
#distance = tf.sqrt(tf.reduce_sum(tf.square(tf.sub(x_data_train, tf.expand_dims(x_data_test,1))), reduction_indices=1))

# Predict: Get min distance index (Nearest neighbor)
top_k_xvals, top_k_indices = tf.nn.top_k(tf.negative(distance), k=k)
prediction_indices = tf.gather(y_target_train, top_k_indices)
# Predict the mode category
count_of_predictions = tf.reduce_sum(prediction_indices, reduction_indices=1)
prediction = tf.argmax(count_of_predictions, dimension=1)

predictions = sess.run(prediction, feed_dict={x_data_train: x_vals_train, x_data_test: x_vals_test,
                                         y_target_train: y_vals_train})

Nrows = 4
Ncols = 5
for i in range(len(rectangles)):
    plt.subplot(Nrows, Ncols, i+1)
    plt.imshow(np.reshape(x_vals_test[i], [28,28]), cmap='Greys_r')
    plt.title(' Pred: ' + str(predictions[i]),
                               fontsize=8)
    frame = plt.gca()
    frame.axes.get_xaxis().set_visible(False)
    frame.axes.get_yaxis().set_visible(False)
    
plt.show()