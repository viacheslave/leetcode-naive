using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-distance-between-bst-nodes/
	///		Submission: https://leetcode.com/submissions/detail/234787710/
	/// </summary>
	internal class P0783
	{
		public int MinDiffInBST(TreeNode root)
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
