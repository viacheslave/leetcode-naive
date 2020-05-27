using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/subtree-of-another-tree/
	///		Submission: https://leetcode.com/submissions/detail/252381569/
	/// </summary>
	internal class P0572
	{
		public bool IsSubtree(TreeNode s, TreeNode t)
		{
			return Traverse(s, t);
		}

		public bool IsId(TreeNode s, TreeNode t)
		{
			if (s == null && t == null)
				return true;

			if (s == null && t != null)
				return false;
			if (s != null && t == null)
				return false;

			return s.val == t.val &&
					IsId(s.left, t.left) &&
					IsId(s.right, t.right);
		}

		public bool Traverse(TreeNode s, TreeNode t)
		{
			var a = IsId(s, t);

			if (s?.left != null)
				a = a || Traverse(s?.left, t);
			if (s?.right != null)
				a = a || Traverse(s?.right, t);

			return a;
		}
	}
}
