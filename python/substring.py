def search_sub(text, substr):
	if not text or not substr: return -1
	if len(text) < len(substr): return -1
	
	for i in range(len(text) - len(substr)): # N - K
		for j in range(len(substr)):					 # K O(K(N-K))
			if text[i + j] != substr[j]:
				break
			if j == len(substr):	# match
				return i
	return -1

# Problem of Brutal Force 
# Backup 

# KMP Algorithm
# DFA (Deterministic Finite State Automation)
# Implementat DFA as n State Matrix

class DFA:
	def __init__(self, substr):
		# construct a finite state machine based on substr
		# Initial State 
		# 
		
		pass
	def change_state(self, c, current_state):
		pass


def dfa_sub_str(text, substr):
	state = 0
	dfa = DFA(substr)
	for i, c in enumerate(text):
		if state == len(substr): return i
		state = dfa.change_state(c, state)
	return -1