def worstPerformingStock(prices):
    if len(prices) == 0:
        return 0

    res = prices[0][0]
    max = (prices[0][2] - prices[0][1])/prices[0][1]

    for row in prices:
        if ( row[2] - row[1] ) / row[1] < max:
            res = row[0]

    return res

prices = [[1200, 100, 105], [1400, 50, 55]]
print(worstPerformingStock(prices))
