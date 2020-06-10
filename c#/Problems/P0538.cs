using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/convert-bst-to-greater-tree/
	///		Submission: https://leetcode.com/submissions/detail/241990922/
	/// </summary>
	internal class P0538
	{
		public TreeNode ConvertBST(TreeNode root)
		{
			Convert(root, 0);

			return root;
		}

		private int Convert(TreeNode node, int sum)
		{
			if (node == null)
				return 0;

			var right = Convert(node.right, sum);

			var value = right + node.val;

			var left = Convert(node.left, value + sum);

			node.val = value + sum;

			return value + left;
		}
	}
}
