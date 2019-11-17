using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/print-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/242776071/
	/// </summary>
	internal class P0655
	{
		public IList<IList<string>> PrintTree(TreeNode root)
		{
			var lines = new Dictionary<int, int?[]>();
			var shifts = new List<int>();

			Traverse(root, lines, shifts, 0, 0);

			var width = (int)Math.Pow(2, lines.Count) - 1;

			var res = new List<IList<string>>();

			for (int i = 0; i < lines.Count; i++)
			{
				var offset = (int)Math.Pow(2, lines.Count - i - 1) - 1;
				var interval = (int)Math.Pow(2, lines.Count - i);

				var line = new List<string>(Enumerable.Repeat("", width));

				for (int j = 0; j < lines[i].Length; j++)
				{
					var kindex = offset + (j * interval);
					line[kindex] = lines[i][j].HasValue ? lines[i][j].Value.ToString() : "";
				}

				res.Add(line);
			}

			return res;
		}

		private void Traverse(TreeNode node, Dictionary<int, int?[]> lines, List<int> shifts, int level, int shift)
		{
			if (node == null)
				return;

			if (!lines.ContainsKey(level))
				lines.Add(level, new int?[(int)Math.Pow(2, level)]);

			if (level > 0)
				shifts.Add(shift);

			int pos = GetPosition(shifts);
			lines[level][pos] = node.val;

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
