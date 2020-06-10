using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree/
	///		Submission: https://leetcode.com/submissions/detail/312316643/
	/// </summary>
	internal class P1379
	{
		public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
		{
			return Search(cloned, target.val);
		}

		public TreeNode Search(TreeNode node, int value)
		{
			if (node == null)
				return null;

			if (node.val == value)
				return node;

			var left = Search(node.left, value);
			var right = Search(node.right, value);

			return left ?? right;
		}
	}
}
