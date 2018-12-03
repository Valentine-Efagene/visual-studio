from os import walk
import os
from  Tkinter import Entry, StringVar, Button, INSERT, Tk, Label
import Tkconstants, tkFileDialog
import Tkinter as tk
import pickle
import tkMessageBox

def showDirectory():
    directory = tkFileDialog.askdirectory()
    folderPathText.insert(INSERT, directory)

def getDirs():
    f = []
    parent = folderPathText.get()

    for (dirpath, dirnames, filenames) in walk(parent):
        f.extend(dirnames)
        break

    myFile = open('folders', 'a')

    for p in f:
        myFile.write(os.path.join(parent, p).replace('\\', '/'))
        myFile.write('\n')

    myFile.close()
    folderPathText.delete(0, 'end')

root = Tk()
root.geometry('500x100')
root.resizable(0, 0)

folderPathLabel = Label(master = root, text = 'Files Directory')

folderPathText = Entry(master = root, width = 50)

getDirBtn = Button(root, text="...", command=showDirectory, width = 3, padx = 10)
getBtn = Button(root, text="Get", command=getDirs, width = 3, padx = 10)

folderPathLabel.grid(row = 0, column = 0)
getDirBtn.grid(row = 0, column = 2)
folderPathText.grid(row = 0, column = 1)
getBtn.grid(row = 1, column = 0)
root.mainloop()