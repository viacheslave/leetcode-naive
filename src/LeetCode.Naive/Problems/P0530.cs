using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-absolute-difference-in-bst/
	///		Submission: https://leetcode.com/submissions/detail/234766308/
	/// </summary>
	internal class P0530
	{
		public int GetMinimumDifference(TreeNode root)
		{
			var list = new List<int>();

			Grab(root, list);

			list.Sort();

			var minDiff = int.MaxValue;

			for (var i = 1; i < list.Count; i++)
			{
				if (list[i] - list[i - 1] < minDiff)
				{
					minDiff = list[i] - list[i - 1];
				}
			}

			return minDiff;
		}

		void Grab(TreeNode node, List<int> list)
		{
			if (node == null)
				return;

			list.Add(node.val);
			Grab(node.left, list);
			Grab(node.right, list);
		}
	}
}
