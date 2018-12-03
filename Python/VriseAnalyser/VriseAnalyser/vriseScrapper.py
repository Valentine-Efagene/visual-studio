from lxml import html
import io, re

class Vrise():
    def __init__(self, url):
        self.url = url
        
        with io.open(url, 'r', encoding = 'utf-8') as f:
            page = f.read()

        doc = html.fromstring(page)
        self.tr_elements = doc.xpath('//span')

    def isNumber(self, var):
        try:
            num = float(var)
        except Exception:
            return False

        return True

    def getDailyVariations(self):
        dailyVar = []

        for i in range(len(self.tr_elements)):
            tT = self.tr_elements[i].find_class('text_table')

            for t in tT:
                if self.isNumber(t.text_content()):
                    dailyVar.append(t.text_content())

        return dailyVar

    def getLabels(self):
        labels = []

        for i in range(len(self.tr_elements)):
            tT = self.tr_elements[i].find_class('text_table')

            for t in tT:
                if re.search('/', t.text_content()):
                    labels.append(t.text_content())

        return labels

    def getProfits(self):
        profits = []

        for i in range(len(self.tr_elements)):
            tT = self.tr_elements[i].find_class('text_table')

            for t in tT:
                if re.search(' - ', t.text_content()):
                    profits.append(t.text_content())

        return profits
