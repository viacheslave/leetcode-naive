using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/univalued-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/234312184/
	/// </summary>
	internal class P0965
	{
		public bool IsUnivalTree(TreeNode root)
		{
			if (root == null)
				return false;

			var value = root.val;

			return Check(root, value);
		}

		bool Check(TreeNode node, int value)
		{
			if (node == null)
				return true;

			return node.val == value &&
					Check(node.left, value) &&
					Check(node.right, value);
		}
	}
}
