using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-depth-of-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/228184350/
	/// </summary>
	internal class P0111
	{
		public int MinDepth(TreeNode root)
		{
			if (root == null)
				return 0;

			int min = CheckNode(root, 1, 0);

			return min;
		}

		private int CheckNode(TreeNode node, int min, int depth)
		{
			if (node == null)
				return depth;

			depth++;

			if (node.left == null && node.right == null)
			{
				return depth;
			}

			if (node.left != null && node.right != null)
				return Math.Min(
					CheckNode(node.left, min, depth),
					CheckNode(node.right, min, depth)
				);

			if (node.left != null)
				return CheckNode(node.left, min, depth);

			if (node.right != null)
				return CheckNode(node.right, min, depth);

			return depth;
		}
	}
}
