import WebTableScraper

wts = WebTableScraper.WebTableScraper('https://pokemondb.net/pokedex/all')

if wts.checkRowWidth() > 0:
    wts.parseTableHeader()
    wts.checkRowWidth()
    wts.parseData()
    wts.display()
else:
    print( 'No table!' )