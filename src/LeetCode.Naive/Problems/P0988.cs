using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/smallest-string-starting-from-leaf/
	///		Submission: https://leetcode.com/submissions/detail/229103022/
	/// </summary>
	internal class P0988
	{
		public string SmallestFromLeaf(TreeNode root)
		{
			var ss = new SortedSet<string>();
			var sb = new StringBuilder();

			Drill(root, ss, sb);

			return ss.First();
		}

		private void Drill(TreeNode node, SortedSet<string> ss, StringBuilder sb)
		{
			if (node == null)
				return;

			sb.Insert(0, (char)(97 + node.val));

			if (node.left == null && node.right == null)
			{
				ss.Add(sb.ToString());
				sb.Remove(0, 1);
				return;
			}

			Drill(node.left, ss, sb);
			Drill(node.right, ss, sb);

			sb.Remove(0, 1);
		}
	}
}
