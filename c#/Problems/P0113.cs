using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/path-sum-ii/
	///		Submission: https://leetcode.com/submissions/detail/229119594/
	/// </summary>
	internal class P0113
	{
		public IList<IList<int>> PathSum(TreeNode root, int sum)
		{
			var ss = new List<List<int>>();
			var sb = new List<int>();

			Drill(root, ss, sb);

			return ss
					.Where(elem => elem.Sum() == sum)
					.OfType<IList<int>>()
					.ToList();
		}

		private void Drill(TreeNode node, List<List<int>> ss, List<int> sb)
		{
			if (node == null)
				return;

			sb.Add(node.val);

			if (node.left == null && node.right == null)
			{
				ss.Add(new List<int>(sb));
				sb.RemoveAt(sb.Count - 1);
				return;
			}

			Drill(node.left, ss, sb);
			Drill(node.right, ss, sb);

			sb.RemoveAt(sb.Count - 1);
		}
	}
}
