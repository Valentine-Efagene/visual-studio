import os

paths =  os.listdir('C:/Users/valentyne/Documents/python/repos')

for p in paths:
    if not os.path.isdir(p):
        paths.remove(p)

print paths