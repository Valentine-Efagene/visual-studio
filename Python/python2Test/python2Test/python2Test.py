import cv2
import numpy as np

img = cv2.imread('messi.jpg')
cv2.imshow("Image", img)
cv2.waitKey(0)
cv2.destroyAllWindows()