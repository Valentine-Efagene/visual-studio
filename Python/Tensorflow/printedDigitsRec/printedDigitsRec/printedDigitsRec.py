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
from imageToArrayConverter import ImageToArrayConverter
import tensorflow as tf
import matplotlib.pyplot as plt
from tensorflow.python.framework import ops
ops.reset_default_graph()

def vectorized_result(j):
  e = np.zeros((10, 1))
  e[j] = 1.0
  return e

itacTest = ImageToArrayConverter('digits.png')
itacTrain = ImageToArrayConverter('printedDigitsTrain.png')

# Create graph
sess = tf.Session()

y_vals_train = np.zeros( (10, 10) )
y_vals_train[0] = vectorized_result(6).ravel()
y_vals_train[1] = vectorized_result(7).ravel()
y_vals_train[2] = vectorized_result(2).ravel()
y_vals_train[3] = vectorized_result(8).ravel()
y_vals_train[4] = vectorized_result(9).ravel()
y_vals_train[5] = vectorized_result(5).ravel()
y_vals_train[6] = vectorized_result(1).ravel()
y_vals_train[7] = vectorized_result(3).ravel()
y_vals_train[8] = vectorized_result(6).ravel()
y_vals_train[9] = vectorized_result(4).ravel()

x_vals_test = itacTest.getImageAsArray()
x_vals_train = itacTrain.getImageAsArray()
#cv2.imshow('f', np.reshape(x_vals_train[9], (28, 28)))
#cv2.imshow('f', itacTrain.getThresholdedImage())
print(y_vals_train.shape)
print(x_vals_train.shape)
print(x_vals_test.shape)
#print(y_vals_train.shape)
#cv2.waitKey(0)

# Declare k-value and batch size
k = 4

# Placeholders
x_data_train = tf.placeholder(shape=[None, 784], dtype=tf.float32)
x_data_test = tf.placeholder(shape=[None, 784], dtype=tf.float32)
y_target_train = tf.placeholder(shape=[None, 10], dtype=tf.float32)

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
Ncols = 3
for i in range(itacTest.getNumberOfDigits()):
    plt.subplot(Nrows, Ncols, i+1)
    plt.imshow(np.reshape(x_vals_test[i], [28,28]), cmap='Greys_r')
    plt.title(' Pred: ' + str(predictions[i]), fontsize=6)
    frame = plt.gca()
    frame.axes.get_xaxis().set_visible(False)
    frame.axes.get_yaxis().set_visible(False)
    
plt.show()