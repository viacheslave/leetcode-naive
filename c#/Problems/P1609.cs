using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/even-odd-tree/
	///		Submission: https://leetcode.com/submissions/detail/404342855/
	/// </summary>
	internal class P1609
	{
		public bool IsEvenOddTree(TreeNode root)
		{
			var map = new Dictionary<int, List<int>>();

			Traverse(map, root, 0);

			foreach (var entry in map)
			{
				var original = entry.Value;
				var expected = entry.Key % 2 == 0
						? entry.Value.OrderBy(x => x).ToList()
						: entry.Value.OrderByDescending(x => x).ToList();

				var remainder = entry.Key % 2 == 0
						? 1 : 0;

				for (var i = 0; i < entry.Value.Count; i++)
					if (original[i] != expected[i])
						return false;

				if (original.Distinct().Count() != original.Count())
					return false;

				for (var i = 0; i < entry.Value.Count; i++)
					if (original[i] % 2 != remainder)
						return false;
			}

			return true;
		}

		private void Traverse(Dictionary<int, List<int>> map, TreeNode node, int level)
		{
			if (!map.ContainsKey(level))
				map.Add(level, new List<int>());

			map[level].Add(node.val);

			if (node.left != null)
				Traverse(map, node.left, level + 1);

			if (node.right != null)
				Traverse(map, node.right, level + 1);
		}
	}
}
