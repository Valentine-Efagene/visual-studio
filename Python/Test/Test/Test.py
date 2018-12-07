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

path = "digits.png"
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
  #roi = thbw[int(y):int(y+h), int(x):int(x+w)]
  #res = cv2.resize(roi, (28, 28))
  #x_vals_test[i] = res.ravel()
  i += 1

cv2.imshow('d', img)
cv2.waitKey(0)
print(x_vals_test.shape)