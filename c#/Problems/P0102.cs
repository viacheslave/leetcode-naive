﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/binary-tree-level-order-traversal/
	///		Submission: https://leetcode.com/submissions/detail/228185024/
	/// </summary>
	internal class P0102
	{
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			var res = new List<IList<int>>();

			CheckNode(res, root, 0);

			return res;
		}

		private void CheckNode(List<IList<int>> res, TreeNode node, int depth)
		{
			if (node == null)
				return;

			if (res.Count == depth)
				res.Add(new List<int>());

			res[depth].Add(node.val);

			depth++;

			if (node.left != null)
				CheckNode(res, node.left, depth);

			if (node.right != null)
				CheckNode(res, node.right, depth);
		}
	}
}