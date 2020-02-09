using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/
	///		Submission: https://leetcode.com/submissions/detail/251928571/
	/// </summary>
	internal class P1123
	{
		public TreeNode LcaDeepestLeaves(TreeNode root)
		{
			if (root == null)
				return null;

			return Traverse(root, 0).node;
		}

		private (TreeNode node, int depth) Traverse(TreeNode node, int depth)
		{
			if (node.left == null && node.right == null)
				return (node, depth);

			if (node.left == null)
				return Traverse(node.right, depth + 1);

			if (node.right == null)
				return Traverse(node.left, depth + 1);

			var leftres = Traverse(node.left, depth + 1);
			var rightres = Traverse(node.right, depth + 1);

			if (leftres.depth == rightres.depth)
				return (node, leftres.depth);

			if (leftres.depth > rightres.depth)
				return leftres;
			else
				return rightres;
		}
	}
}
