using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/
	///		Submission: https://leetcode.com/submissions/detail/240569449/
	/// </summary>
	internal class P1008
	{
		public TreeNode BstFromPreorder(int[] preorder)
		{
			if (preorder.Length == 0)
				return null;

			var root = new TreeNode(preorder[0]);
			if (preorder.Length == 1)
				return root;

			for (int i = 1; i < preorder.Length; i++)
				Insert(root, preorder[i]);

			return root;
		}

		private void Insert(TreeNode node, int v)
		{
			if (v > node.val)
			{
				if (node.right == null)
				{
					node.right = new TreeNode(v);
					return;
				}
				Insert(node.right, v);
			}

			if (v < node.val)
			{
				if (node.left == null)
				{
					node.left = new TreeNode(v);
					return;
				}
				Insert(node.left, v);
			}
		}
	}
}
