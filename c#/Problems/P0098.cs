using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/validate-binary-search-tree/
	///		Submission: https://leetcode.com/submissions/detail/226150107/
	/// </summary>
	internal class P0098
	{
		public bool IsValidBST(TreeNode root)
		{
			List<int> arr = new List<int>();

			return CheckNode(root, arr);
		}

		private bool CheckNode(TreeNode node, List<int> arr)
		{
			if (node == null)
				return true;

			if (node.left != null)
				if (!CheckNode(node.left, arr))
					return false;

			arr.Add(node.val);
			if (arr.Count > 1 && arr[arr.Count - 2] >= node.val)
				return false;

			if (node.right != null)
				if (!CheckNode(node.right, arr))
					return false;

			return true;
		}
	}
}
