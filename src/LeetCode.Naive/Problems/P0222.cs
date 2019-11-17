using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-complete-tree-nodes/
	///		Submission: https://leetcode.com/submissions/detail/237351378/
	/// </summary>
	internal class P0222
	{
		public int CountNodes(TreeNode root)
		{
			return Count(root);
		}

		public int Count(TreeNode node)
		{
			if (node == null)
				return 0;

			return 1 + Count(node.left) + Count(node.right);
		}
	}
}
