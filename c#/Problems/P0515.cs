using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-largest-value-in-each-tree-row/
	///		Submission: https://leetcode.com/submissions/detail/234773773/
	/// </summary>
	internal class P0515
	{
		public IList<int> LargestValues(TreeNode root)
		{
			var max = new Dictionary<int, int>();

			Traverse(root, max, 0);

			return max
					.OrderBy(_ => _.Key)
					.Select(_ => _.Value)
					.ToList();
		}

		void Traverse(TreeNode node, Dictionary<int, int> max, int line)
		{
			if (node == null)
				return;

			if (!max.ContainsKey(line))
				max[line] = int.MinValue;

			if (node.val > max[line])
				max[line] = node.val;

			Traverse(node.left, max, line + 1);
			Traverse(node.right, max, line + 1);
		}
	}
}
