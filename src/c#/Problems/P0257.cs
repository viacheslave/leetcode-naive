using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/valid-anagram/
	///		Submission: https://leetcode.com/submissions/detail/229104100/
	/// </summary>
	internal class P0257
	{
		public IList<string> BinaryTreePaths(TreeNode root)
		{
			var ss = new List<string>();
			var sb = new List<string>();

			Drill(root, ss, sb);

			return ss;
		}

		private void Drill(TreeNode node, List<string> ss, List<string> sb)
		{
			if (node == null)
				return;

			sb.Add(node.val.ToString());

			if (node.left == null && node.right == null)
			{
				ss.Add(string.Join("->", sb.ToArray()));
				sb.RemoveAt(sb.Count - 1);
				return;
			}

			Drill(node.left, ss, sb);
			Drill(node.right, ss, sb);

			sb.RemoveAt(sb.Count - 1);
		}
	}
}
