def longest_non_repeat(str):
	# Method 1, Brutal Force,
	maxLen = 0
	
	for i in range(0, len(str)):
		charSet=Set([str[i]])
		l = 1
		for j in range(i, len(str)):
			if str[j] in charSet:
				break
			l+=1
			charSet.put(str[j])
		maxLen = l if l > maxLen else maxLen
	
	return maxLen

def longest_non_repeat_2(str):
	maxLen = 0
	tempMax = 0
	dict = {}	# Constant Space as max is the possibility of the characters
	last = 0
	for i in range(0, len(str)):
		c = str[i]
		if c in dict and dict[c] > last:
			tempMax = i - dict[c]	# reset to index differences
			last = dict[c]
			dict[c] = i			
		else:
			dict[c] = i
			tempMax += 1
			
		maxLen = tempMax if tempMax > maxLen else maxLen
		
