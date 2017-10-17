from pprint import pprint

def gen_permutations(lst):
    if len(lst) == 2:
        return [[lst[0], lst[1]], [lst[1], lst[0]]]
    if len(lst) <= 1: return lst

    fst = lst[0]
    lowP = gen_permutations(lst[1:])
    res = []
    for i in range(len(lowP)):
        for j in range(len(lowP[i]) + 1):
            ex = lowP[i][:j]
            ex.append(fst)
            ex.extend(lowP[i][j:])
            res.append(ex)
    return res

pprint(gen_permutations([1, 2, 3, 4]))
pass
