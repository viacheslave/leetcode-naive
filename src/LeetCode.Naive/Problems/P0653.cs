using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
	///		Submission: https://leetcode.com/submissions/detail/244152994/
	/// </summary>
	internal class P0653
	{
		public bool FindTarget(TreeNode root, int k)
		{
			if (root == null)
				return false;

			return Pick(root, root, k);
		}

		private bool Pick(TreeNode root, TreeNode node, int k)
		{
			if (node == null)
				return false;

			return Search(root, node, k)
				|| Pick(root, node.left, k)
				|| Pick(root, node.right, k);
		}

		private bool Search(TreeNode searchNode, TreeNode node, int k)
		{
			if (searchNode == null || searchNode == node)
				return false;

			return searchNode.val + node.val == k
				|| Search(searchNode.left, node, k)
				|| Search(searchNode.right, node, k);
		}
	}
}
