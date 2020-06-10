using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/binary-tree-pruning/
	///		Submission: https://leetcode.com/submissions/detail/239337707/
	/// </summary>
	internal class P0814
	{
		public TreeNode PruneTree(TreeNode root)
		{
			Traverse(root);
			return root;
		}

		private void Traverse(TreeNode node)
		{
			if (node == null)
				return;

			Traverse(node.left);
			Traverse(node.right);

			if (node.left != null && node.left.val == 0 && (node.left.left == null && node.left.right == null))
				node.left = null;

			if (node.right != null && node.right.val == 0 && (node.right.left == null && node.right.right == null))
				node.right = null;
		}
	}
}
