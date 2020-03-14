using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/most-frequent-subtree-sum/
	///		Submission: https://leetcode.com/submissions/detail/249968602/
	/// </summary>
	internal class P0508
	{
		public int[] FindFrequentTreeSum(TreeNode root)
		{
			if (root == null)
				return new int[0];

			var sums = new List<int>();

			var value = GetSubTreeValue(root, sums);
			sums.Add(value);

			var countMap = sums.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());
			var maxCount = countMap.Max(_ => _.Value);
			return countMap.Where(_ => _.Value == maxCount).Select(_ => _.Key).ToArray();
		}

		private int GetSubTreeValue(TreeNode node, List<int> sums)
		{
			var list = new List<int>();

			if (node.left != null)
				list.Add(GetSubTreeValue(node.left, sums));

			if (node.right != null)
				list.Add(GetSubTreeValue(node.right, sums));

			sums.AddRange(list);
			return list.Sum() + node.val;
		}
	}
}
