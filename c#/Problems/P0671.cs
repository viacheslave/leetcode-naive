using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/229998868/
	/// </summary>
	internal class P0671
	{
		List<int> mins = new List<int>();

		public int FindSecondMinimumValue(TreeNode root)
		{
			Traverse(root);

			var ar = mins.Distinct().ToArray();
			Array.Sort(ar);

			if (ar.Length < 2)
				return -1;

			return ar[1];
		}

		void Traverse(TreeNode node)
		{
			var val = node.val;

			if (node.left != null && node.right != null)
			{
				val = Math.Min(node.left.val, node.right.val);

				Traverse(node.left);
				Traverse(node.right);
			}

			mins.Add(val);
		}
	}
}
