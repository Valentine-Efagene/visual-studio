from  Tkinter import Entry, StringVar, Button, INSERT, Tk, Label
import Tkconstants, tkFileDialog
import Tkinter as tk
import pickle
import tkMessageBox
import os
from openpyxl import Workbook
import sys

def save():
    directory = folderPathText.get()

    if os.path.exists(directory):
        p_out = open('watchFolder', 'wb')
        pickle.dump(directory, p_out)
        p_out.close()
    else:
        tkMessageBox.showerror('ERROR', 'Please select a directory to watch.')
        
    wb = Workbook()
    wb.save("minutes.xlsx")
    sys.exit(0)

def showDirectory():
    directory = tkFileDialog.askdirectory()
    print directory
    folderPathText.insert(INSERT, directory)

root = Tk()
root.geometry('500x100')
#root.resizable(0, 0)

folderPathLabel = Label(master = root, text = 'Files Directory')

folderPathText = Entry(master = root, width = 50)

getDirBtn = Button(root, text="...", command=showDirectory, width = 3, padx = 10)
saveBtn = Button(root, text="save", command=save, width = 3, padx = 10)

folderPathLabel.grid(row = 0, column = 0)
getDirBtn.grid(row = 0, column = 2)
folderPathText.grid(row = 0, column = 1)
saveBtn.grid(row = 1, column = 0)
root.mainloop()