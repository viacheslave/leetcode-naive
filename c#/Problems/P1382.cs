using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/balance-a-binary-search-tree/
	///		Submission: https://leetcode.com/submissions/detail/312640224/
	/// </summary>
	internal class P1382
	{
		public TreeNode BalanceBST(TreeNode root)
		{
			var list = new List<TreeNode>();
			FillNodes(root, list);

			list = list.OrderBy(e => e.val).ToList();

			return GetMiddle(list);
		}

		private TreeNode GetMiddle(List<TreeNode> list)
		{
			if (list.Count == 0)
				return null;

			if (list.Count == 1)
				return new TreeNode(list[0].val);

			var middle = list.Count / 2;

			var middleNode = new TreeNode(list[middle].val);
			middleNode.left = GetMiddle(list.Take(middle).ToList());
			middleNode.right = GetMiddle(list.Skip(middle + 1).ToList());

			return middleNode;
		}

		private void FillNodes(TreeNode node, List<TreeNode> list)
		{
			if (node == null) return;

			list.Add(node);
			FillNodes(node.left, list);
			FillNodes(node.right, list);
		}
	}
}
