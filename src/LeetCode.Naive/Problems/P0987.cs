using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/241018652/
	/// </summary>
	internal class P0987
	{
		public IList<IList<int>> VerticalTraversal(TreeNode root)
		{
			if (root == null)
				return new List<IList<int>>();

			var map = new SortedDictionary<int, List<(int, int)>>();

			Traverse(root, map, 0, 0);

			var result = new List<IList<int>>();

			foreach (var mapItem in map)
			{
				var items = mapItem.Value
						.OrderBy(_ => _.Item2)
						.ThenBy(_ => _.Item1)
						.Select(_ => _.Item1)
						.ToList();

				result.Add(items);
			}

			return result;
		}

		private void Traverse(TreeNode node, SortedDictionary<int, List<(int, int)>> map, int level, int shift)
		{
			if (node == null)
				return;

			Traverse(node.left, map, level + 1, shift - 1);

			if (!map.ContainsKey(shift))
				map[shift] = new List<(int, int)>();

			map[shift].Add((node.val, level));

			Traverse(node.right, map, level + 1, shift + 1);
		}
	}
}
