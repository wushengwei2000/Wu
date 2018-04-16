class TreeNode:
	def __init__(self, val, left, right, meta):
		self.val = val
		self.left = left
		self.right = right
		self.meta = meta

class BST:
	def __init__(self, root):
		self.root = root

	def insert(self, val):
		node = self.root
		while node is not None:
			if val <= node.val:
				node = node.left
			else:
				node = node.right
		node = TreeNode(val, None, None, None)
	
	def delete(self, val):
		pass
	
	def max(self):
		if self.root is None:
			return None
		
		node = self.root
		while node.right is not None:
			node = node.right
		return node.val
	
	def min(self):
		if self.root is None:
			return None
		
		node = self.root
		while node.left is not None:
			node = node.left
		return node.val
	
	def seach(self, target):
		node = self.root
		while True:
			if node is None:
				return False
			if node.val == target:
				return True
			elif target < node.val:
				node = node.left
			else:
				node = node.right
	
	def depth(self):
		pass




