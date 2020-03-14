using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/delete-leaves-with-a-given-value/
	///		Submission: https://leetcode.com/submissions/detail/295935692/
	/// </summary>
	internal class P1325
	{
		public TreeNode RemoveLeafNodes(TreeNode root, int target)
		{
			var res = Traverse(root, target);
			if (res)
				return null;

			return root;
		}

		private bool Traverse(TreeNode node, int target)
		{
			if (node == null)
				return true;

			var lr = Traverse(node.left, target);
			var rr = Traverse(node.right, target);

			if (lr)
				node.left = null;
			if (rr)
				node.right = null;

			return lr && rr && node.val == target;
		}
	}
}
