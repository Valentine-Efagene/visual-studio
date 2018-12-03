#Ref: https://towardsdatascience.com/web-scraping-html-tables-with-python-c9baba21059

import requests
import lxml.html as lh
import pandas as pd

class WebTableScraper:
    def __init__(self, url):
        self.url = url
        self.rowWidth = 0
        page = requests.get(url) #Create a handle, page, to handle the contents of the website
        self.doc = lh.fromstring(page.content)
        self.tr_elements = self.doc.xpath('//tr') #Store the contents of the website under doc
        
    def checkRowWidth(self):
        rowWidths = [len(T) for T in self.tr_elements[:len(self.tr_elements)]]
        if len(self.tr_elements) > 0:
            self.rowWidth = rowWidths[0]
        return self.rowWidth

    #Parse data that are stored between <tr>..</tr> of HTML.
    #Parse the first row as header.
    def parseTableHeader(self):
        self.col = []
        i = 0

        for t in self.tr_elements[0]:
            i += 1
            name = t.text_content()
            print( '%d:"%s"' %(i, name) )
            self.col.append( ( name, [] ) )

    def parseData(self):
        #Since out first row is the header, data is stored on the second row onwards
        for j in range(1,len(self.tr_elements)):
            #T is our j'th row
            T=self.tr_elements[j]
    
            #If row is not of size rowWidth, the //tr data is not from our table 
            if len(T)!=self.rowWidth:
                break
    
            #i is the index of our column
            i=0
    
            #Iterate through each element of the row
            for t in T.iterchildren():
                data=t.text_content() 
                #Check if row is empty
                if i>0:
                #Convert any numerical value to integers
                    try:
                        data=int(data)
                    except:
                        pass
                #Append the data to the empty list of the i'th column
                self.col[i][1].append(data)
                #Increment i for the next column
                i+=1

    def display(self):
        Dict={title:column for (title,column) in self.col}
        df=pd.DataFrame(Dict)
        print (df.head())