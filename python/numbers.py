# def numbers_to_roman(number):
# 	if number == 0:
# 		return ""
# 	if number < 5:
# 		return "I"*number
# 	if number < 10 and number >=5:
# 		return "V" + numbers_to_roman(number%5)	
# 	if number >=10 and number < 50:
# 		return numbers_to_roman(int(number / 10)) + "X" + numbers_to_roman(number % 10)
# 	if number >=50 and number < 100
# 		return numbers_to_roman(int(number / 50)) + "L" + numbers_to_roman(number % 50)
# 	if number >=100 and number <500
# 		return numbers_to_roman(int(number / 100)) + "C" + numbers_to_roman(number % 100)
# 	if number >=500 and number <1000
# 		return numbers_to_roman(int(number / 500)) + "M" + numbers_to_roman(number % 500)

# dict_roman = [(1, "I"), (1, "I"), (1, "I"), (1, "I"), (1, "I"), (1, "I")]	# construct an array of tuple (num, Roman)
# def number_to_roman(number, i):
# 	if number < dict_roman[i][0]:
# 		return number_to_roman(number, i + 1)


def max_capacity(nums):
	# find the max capacties from these arrays
	n1, p1 = 0, 0
	n2, p2 = len(nums) - 1, len(nums) - 1
	maxC = 0
	while p1 < p2:
		c = (p2 - p1) * min(nums[p1], nums[p2])
		if c > maxC:
			n1, n2 = p1, p2
			maxC = c
		if nums[p1] <= nums[p2]:
			p1 = p1 + 1
		else:
			p2 = p2 - 1
	return (maxC, n1, n2)

print (max_capacity([1,2, 3]))
print (max_capacity([1,2]))
print (max_capacity([1,2,3,20,40, 5]))


def reverse_word(str):
	
