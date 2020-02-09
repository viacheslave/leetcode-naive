using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/path-sum/
	///		Submission: https://leetcode.com/submissions/detail/227431181/
	/// </summary>
	internal class P0112
	{
		public bool HasPathSum(TreeNode root, int sum)
		{
			if (root == null)
				return false;

			var s = 0;

			return CheckSum(root, s, sum);
		}

		private bool CheckSum(TreeNode node, int s, int sum)
		{
			s = s + node.val;

			if (node.left == null && node.right == null)
			{
				if (s == sum)
					return true;
				else
					return false;
			}

			if (node.left != null && node.right != null)
			{
				return CheckSum(node.left, s, sum) || CheckSum(node.right, s, sum);
			}

			if (node.left != null)
				return CheckSum(node.left, s, sum);

			else if (node.right != null)
				return CheckSum(node.right, s, sum);

			return false;
		}
	}
}
