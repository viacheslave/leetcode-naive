using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sum-root-to-leaf-numbers/
	///		Submission: https://leetcode.com/submissions/detail/229100839/
	/// </summary>
	internal class P0129
	{
		public int SumNumbers(TreeNode root)
		{
			return GetSum(root, 0);
		}

		int GetSum(TreeNode node, int current)
		{
			if (node == null)
				return 0;

			if (node.left == null && node.right == null)
				return current * 10 + node.val;

			var left = GetSum(node.left, current * 10 + node.val);
			var right = GetSum(node.right, current * 10 + node.val);

			return left + right;
		}
	}
}
