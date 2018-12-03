import numpy as np
import matplotlib.pyplot as plt

def generate_data(num_samples, num_features = 2):
    data_size = (num_samples, num_features)
    data = np.random.randint(0, 100, size = data_size)
    label_size = (num_samples, 1)
    labels = np.random.randint(0, 2, size = label_size)
    return data.astype(np.float32), labels

def plot_data(all_blue, all_red):
    plt.scatter(all_blue[:, 0], all_blue[:, 1], c = 'b', marker = 's', s = 180)
    plt.scatter(all_red[:, 0], all_red[:, 1], c = 'r', marker = '^', s = 180)
    plt.xlabel('x coordinate (feature 1)')
    plt.ylabel('y coordinate (feature 2)')

train_data, labels = generate_data(100, 2)
blue = train_data[labels.ravel() == 0]
red = train_data[labels.ravel() == 1]
plot_data(blue, red)

newcomer, _ = generate_data(1)
plt.plot(newcomer[0, 0], newcomer[0, 1], 'go', markersize = 14)
plt.show()