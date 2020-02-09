using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/253930319/
	/// </summary>
	internal class P1161
	{
		public int MaxLevelSum(TreeNode root)
		{
			if (root == null)
				return 0;

			var map = new Dictionary<int, int>();
			Traverse(root, map, 1);

			return map.OrderByDescending(_ => _.Value).First().Key;
		}

		private void Traverse(TreeNode node, Dictionary<int, int> map, int level)
		{
			if (node == null)
				return;

			if (!map.ContainsKey(level))
				map[level] = 0;

			map[level] += node.val;
			Traverse(node.left, map, level + 1);
			Traverse(node.right, map, level + 1);
		}
	}
}
