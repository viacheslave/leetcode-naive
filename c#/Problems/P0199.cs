using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/binary-tree-right-side-view/
	///		Submission: https://leetcode.com/submissions/detail/237812460/
	/// </summary>
	internal class P0199
	{
		public IList<int> RightSideView(TreeNode root)
		{
			var res = new List<int>();
			if (root == null)
				return res;

			Traverse(root, res, 0);

			return res;
		}

		void Traverse(TreeNode node, List<int> res, int d)
		{
			if (node == null)
				return;

			if (res.Count < d + 1)
				res.Add(node.val);

			Traverse(node.right, res, d + 1);
			Traverse(node.left, res, d + 1);
		}
	}
}
