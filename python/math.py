# How to find the hcd

def greatest_common_divisor(a, b):
	while b:
		a, b = b, a % b		# a = 10, b = 4; a = 10, b 3 => 3, 1 => 1, 0
	return a
