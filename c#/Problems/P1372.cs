using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/310835420/
	/// </summary>
	internal class P1372
	{
		public int LongestZigZag(TreeNode root)
		{
			var map = new Dictionary<TreeNode, (int, int)>();
			Traverse(root, map);

			return map.Values
					.Select(x => new int[] { x.Item1, x.Item2 })
					.SelectMany(x => x)
					.Max();
		}

		private void Traverse(TreeNode node, Dictionary<TreeNode, (int, int)> map)
		{
			var left = 0;
			var right = 0;

			if (node.left != null)
			{
				Traverse(node.left, map);
				left = map[node.left].Item2 + 1;
			}

			if (node.right != null)
			{
				Traverse(node.right, map);
				right = map[node.right].Item1 + 1;
			}

			map[node] = (left, right);
		}
	}
}
