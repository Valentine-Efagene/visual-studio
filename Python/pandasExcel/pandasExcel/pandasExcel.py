import pandas as pd
import xlrd

def getData( columnLabel, index ):
    return df[str(columnLabel)][index]

def getHeading():
    return df.columns

def getColumn( columnLabel ):
    return df[str(columnLabel)]

df = pd.read_excel('pandasTest.xlsx', sheet_name = 'Sheet1')
print(getData( 'event', 0 ))