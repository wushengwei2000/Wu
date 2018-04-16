# Graph Problem

## Representations
1. Adjacent List
1. Adjacent Matrix

## Categories
|							| Undirected										| Directed 											|
|:----------- |: ------------ 								|:------------									|
|Unweighted		|	Connected Components				 	|	Topology Sort									|
|							|																|	Cycle Detections							|
|							|																|	Strongly Connected Components	|
|Weighted			|	Prims Algorithm								|	Shoreted Path Problem					|
|							|	MSP														|																|
|							|																|																|

### Topology Sort Problem and Algorithm 


### Connected / Strongly Connected Component Problem
	1. DFS / BFS implementation 
	1. Kosaraju Algorithm 
		2. Compute topological sort of the reverse Diagraph
		2. Loop through the order and compute the strongly connected components

### Shortest Path Algorithm 
	1. Dijkstra's Algorithm (Non Negative Weight)
		2. initialize ajacent to max value
		2. set starting point to 0
		2. Calculate distance for reachable vertices 
		2. Sort the known distance (using priority queue for example, heaq.push(, dict[distance][0]))
		2. Pop the shortest distance into the SPT set
		2. remove distance from heap and go back to step `Calculate distance for reachable vertices`
	
	1. Topological Sort (if DAG)
		2. Initialize list to max value
		2. Topological Sort DAG
		2. Foreach the sorted Vertices, update its adjacent vertex' distance
	
	1. Critical Path Method (CPM)
		2. !!!! Contructing a graph with empty source node and sink node !!! clever and important
		2. Find the longest path (AKA: critical path)
		2. Schedule along with the longest path
	
	1. Bellman-Ford Algorithm

### Mininum Cut Problem (Find a cut to minimize the capactiy)
	#### Theory
		Maxflow === Sum (Mincut Edge Capacity(weight)) 
	#### Algorithm:
	1. Fort-Fulkerson algorithm
		How to find augmented path:
			- Has forward capacity remaining 
			- Has backward capacity to reduce
		while there is augmented path:
			find the bottleneck flow and increase the flow along the augmented path
	1. How to implement Fort-Fulkerson Algorithm
		2. Graph ===> Residue Graph
		2. Perform DFS or BFS on the residue graph



#### Application
	1. Path finding, Navigation 
	1. Parallel Scheduling Problem
		e.g. Longest Path (Scheduling Problem): convert to shortest path problem by negate the weight
		> How to represent this problem 
		>  

# Generic Algorithm Philosiphy
## Dynamic Programming 
	Break down large problem into smaller pieces, solving small problem and memorize the results to optimize the algorithm
	Guaranteed to be optimal solution
	e.g. DFS is considered as Dynamic Programming
		Actually most of the recursive algorithm are based on the concept of dynamic programming

## Greedy Programming 
	Find local optimal solution hopefully that you can find the global optimal solution
	Does not really guarantee optimal solution
	e.g. Minimum Spanning Tree 
		Prim Algorithm

## Reduction / Induction 

## Divide and Conquer and Combine 
	- Divide n -> 1 + (n-1) (N2)
	- Divide n -> n/2 + n/2 (lg(N)); Think about using this instead


# All the problem can be solved by 
# 	- Reduction: universal -> contextual 
#		- Induction: contextual -> universal 
# 	- Divide and Conquer and Combine

# Graph Problems 
# 1. Dependency Checkings 
# Topological Sort: 
# 	Dealing with depencies problems 
#		Direct Acyclic graph (DAG) 
#		All edeges pointing forward
# Can be part of digraph (Directed Graph) problem
#
#	2. Directed Cycle Detection
#		Topological Sorting is only possible if there is no cycle
#		DFS searched will be the reverse topological order
#
#	3. Connected Components (island) vs Strongly Connected Components
# 	Kosaraju Algorithm


# Weighted Diagraph Problem 
#
# Minimum Spanning Tree (Greedy Algorithm)
#		Undirect Weighted Graph
#		

# How to implement a Tri Diagraph






# Sorting 
# 	Insertion Sort
# 	Selection Sort 


# Data Strucutre 
# 	