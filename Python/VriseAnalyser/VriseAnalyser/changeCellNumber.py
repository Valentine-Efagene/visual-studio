from  Tkinter import Entry, StringVar, Button, INSERT, Tk, Label
import Tkconstants, tkFileDialog
import Tkinter as tk
import pickle
import tkMessageBox
import os

def save():
    try:
        cellNumber = int(cellNumberText.get())
        p_out = open('cellNumber', 'wb')
        pickle.dump(cellNumber, p_out)
        p_out.close()   
    except ValueError:
        tkMessageBox.showerror('ERROR', 'Please enter an integer.')

def view():
    try:
        if os.path.exists('cellNumber'):
            p_in = open('cellNumber', 'r')
            cellNumber = pickle.load(p_in)
            p_in.close()
            currentCellNumberText.delete(0, 'end')
            currentCellNumberText.insert(INSERT, cellNumber)
        else:
            tkMessageBox.showerror('ERROR', 'No file!')    
    except ValueError:
        tkMessageBox.showerror('ERROR', 'Please enter an integer.')



root = Tk()
root.geometry('500x100')
root.resizable(0, 0)

cellNumberLabel = Label(master = root, text = 'Cell Number')
currentCellNumberLabel = Label(master = root, text = 'Current Cell Number')

cellNumberText = Entry(master = root, width = 50)
currentCellNumberText = Entry(master = root, width = 50)

saveBtn = Button(root, text="save", command=save, width = 3, padx = 10)
currentCellNumberBtn = Button(root, text="Current", command=view, width = 3, padx = 10)

cellNumberLabel.grid(row = 0, column = 0)
saveBtn.grid(row = 0, column = 2)
cellNumberText.grid(row = 0, column = 1)
currentCellNumberLabel.grid(row = 1, column = 0)
currentCellNumberText.grid(row = 1, column = 1)
currentCellNumberBtn.grid(row = 1, column = 2)
root.mainloop()