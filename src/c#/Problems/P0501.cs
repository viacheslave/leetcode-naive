using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-mode-in-binary-search-tree/
	///		Submission: https://leetcode.com/submissions/detail/234907992/
	/// </summary>
	internal class P0501
	{
		public int[] FindMode(TreeNode root)
		{
			if (root == null)
				return Array.Empty<int>();

			var map = new Dictionary<int, int>();

			Traverse(root, map);

			var max = map.Values.Max();
			return map
					.Where(_ => _.Value == max)
					.Select(_ => _.Key)
					.ToArray();
		}

		void Traverse(TreeNode node, Dictionary<int, int> map)
		{
			if (node == null)
				return;

			if (!map.ContainsKey(node.val))
				map[node.val] = 0;

			map[node.val]++;

			Traverse(node.left, map);
			Traverse(node.right, map);
		}
	}
}
