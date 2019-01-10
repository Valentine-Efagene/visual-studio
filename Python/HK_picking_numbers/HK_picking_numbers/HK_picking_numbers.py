def pick(a):
    max_so_far = 1
    a = sorted(a)
    max_ending_here = 1
    trans = 0

    for i in range(len(a) - 1):
        if (a[i + 1] - a[i] == 0) or (a[i + 1] - a[i] == 1 and trans < 1):
            max_ending_here += 1

            if a[i + 1] - a[i] == 1:
                trans += 1
        else:
            max_ending_here = 1
            trans = 0
            
        if max_ending_here > max_so_far:
            max_so_far = max_ending_here

    print(max_so_far)

#a = [4, 4, 6, 6, 5, 6, 8, 7, 6, 8, 5, 3, 2, 1, 2, 1, 3, 2]
#a = [4, 6, 5, 3, 3, 1]
#a = [1, 2, 2, 3, 1, 2]
a = [0, 1]
pick(a)