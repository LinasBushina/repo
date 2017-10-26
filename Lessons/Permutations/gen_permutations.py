def gen_permutations(lst):
	if len(lst) == 2:
		return [[lst[0], lst[1]], [lst[1], lst[0]]]
	if len(lst) <= 1: return lst

	fst = lst[0]
	ex = gen_permutations[lst[1:]]
	res = [[fst].extend(ex[0])]
	for i in range(1, len(ex)):
		pass

gen_permutations([1, 2, 3])