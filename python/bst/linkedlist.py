class ListNode:
	def __init__(self, val):
		self.val = val
		self.next = None

class MergeList:
	def merge(self, p1, p2):
		root = ListNode(None)
		p = root
		while p1 or p2:
			if not p1:
				p.next = p2
				break
			if not p2:
				p.next = p1
				break
			if p1.val <= p2.val:
				p.next = p1
				p1 = p1.next
			else:
				p.next = p2
				p2 = p2.next
			p = p.next
		return root.next
	
	def add(self, n1, n2):
		header = ListNode(0)
		p = header
		plus = 0
		while n1 or n2:
			tempSum = (0 if not n1 else n1.val) + (0 if not n2 else n2.val) + plus
			val = tempSum if tempSum < 10 else 0
			plus = 0 if tempSum < 10 else 1
			p.next = ListNode(val)
			p = p.next
			n1 = None if not n1 else n1.next
			n2 = None if not n2 else n2.next
		# Missing => this is the problem
		if plus > 0:
			p.next = ListNode(1)
		return header.next
	
	def swap(self, list):
		if not list:
			return list
		head = ListNode(0)
		head.next = list
		p1 = head.next
		p2 = p1.next
		while p1 and p2:
			# Swap the value
			temp = p1.val
			p1.val = p2.val
			p2.val = temp
			# Move to the next
			p1 = p2.next
			if not p1:
				break
			p2 = p1.next

		return head.next
