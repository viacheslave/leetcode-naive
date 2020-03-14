using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-width-of-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/242818524/
	/// </summary>
	internal class P0662
	{
		public int WidthOfBinaryTree(TreeNode root)
		{
			var lines = new Dictionary<int, List<int>>();
			var shifts = new List<int>();

			Traverse(root, lines, shifts, 0, 0);

			var max = 1;
			for (int i = 1; i < lines.Count; i++)
			{
				max = Math.Max(max, lines[i].Max() - lines[i].Min() + 1);
			}

			return max;
		}

		private void Traverse(TreeNode node, Dictionary<int, List<int>> lines, List<int> shifts, int level, int shift)
		{
			if (node == null)
				return;

			if (!lines.ContainsKey(level))
				lines.Add(level, new List<int>());

			if (level > 0)
				shifts.Add(shift);

			int pos = GetPosition(shifts);
			lines[level].Add(pos);

			Traverse(node.left, lines, shifts, level + 1, 0);
			Traverse(node.right, lines, shifts, level + 1, 1);

			if (level > 0)
				shifts.RemoveAt(shifts.Count - 1);
		}

		private int GetPosition(List<int> shifts)
		{
			var value = 0;
			for (int i = shifts.Count - 1; i >= 0; i--)
				value += (int)Math.Pow(2, shifts.Count - i - 1) * shifts[i];

			return value;
		}
	}
}
