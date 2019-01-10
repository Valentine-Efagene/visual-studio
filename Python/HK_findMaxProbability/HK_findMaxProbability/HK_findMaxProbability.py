from itertools import combinations

def findMaxGoalsProbability(teamGoals):
    comb = combinations(teamGoals, 2)
    games = list(comb)
    goals = [game[0] + game[1] for game in games]
    most = max(goals)
    count = 0

    for x in goals:
        if x == most:
            count += 1

    prob = count / len(goals)
    a = "%.2f" %prob
    return a

teamGoals = [1, 2, 2, 3]
print(findMaxGoalsProbability(teamGoals))
