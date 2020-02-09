using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-depth-of-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/226725806/
	/// </summary>
	internal class P0104
	{
		public int MaxDepth(TreeNode root)
		{
			int d = 1;
			return GetMaxDepth(root, 1);
		}

		private int GetMaxDepth(TreeNode node, int d)
		{
			if (node == null)
				return 0;

			if (node.left == null && node.right == null)
				return 1;

			var left = 0;
			var right = 0;

			if (node.left != null)
				left = GetMaxDepth(node.left, d);
			if (node.right != null)
				right = GetMaxDepth(node.right, d);

			if (left > right)
				return d + left;
			if (left < right)
				return d + right;
			return d + left;
		}
	}
}
