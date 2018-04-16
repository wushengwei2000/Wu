def naive_topology_sort(G, S=None):
	"""
	topology_sort child
	for all the sorted list, 
		insert after parent, predesessor
	"""
	if S is None: S=set(G)
	if len(S) == 1: return list(S)
	node = S.pop()
	tlist = naive_topology_sort(G, S)
	pos = 0
	for i, u in enumerate(tlist):
		if node in G[u]:
			pos = i + 1
	tlist.insert(pos, node)
	return tlist

def counting_topology_sort(G):
	"""
	Use DFS to get reverse post order of nodes
	"""
	res = []
	for v in G:
		dfs(G, v, [], res)
	res.reverse()
	return res
	
# Use Postorder
def dfs(G, v, visited, postorder):
	if v in visited: return
	visited.add(v)
	for a in G[v]:
		dfs(G, a, visited, postorder)
	postorder.append(v)

def reverseGraph(G):
	RG = {}
	for v in G:
		for u in G[v]:
			RG[u] = set() if not RG[u] else RG[u]
			RG[u].add(v)
	return RG

def kosaraju_strong_component(G):
	"""
	1. Compute Reversed Postorder of G(r) Reversed Digraph AKA: topological sort of ReverseGraph(G)
	2. DFS(G) based on the Topological Sort Result of 1 
	"""
	result = []
	# Step 1
	RG = reverseGraph(G)
	rtpSorted = counting_topology_sort(RG)
	
	# Step 2
	visited = set()
	for v in rtpSorted:
		c = []
		dfs(G, v, visited, c)
		result.append(c) # append strong components
	return result


# How to represent a diagram 
# 1. Adjacent list/set/dict
G = {
	'a': {'b', 'c', 'd'},
	'b': {'a'}
}
# 2. Adjacent Matrix
G = [
	[1, 0],
	[0, 1]
]
