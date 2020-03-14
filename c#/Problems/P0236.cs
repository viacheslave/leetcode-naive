using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/242485399/
	/// </summary>
	internal class P0236
	{
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{
			if (root == null)
				return null;

			var st1 = new List<TreeNode>();
			var st2 = new List<TreeNode>();

			Traverse(root, p, st1);
			Traverse(root, q, st2);

			int index = 0;
			while (index < st1.Count && index < st2.Count && st1[index] == st2[index])
			{
				index++;
				continue;
			}

			return st1[index - 1];
		}

		private bool Traverse(TreeNode node, TreeNode search, List<TreeNode> list)
		{
			if (node == null)
				return false;

			list.Add(node);

			if (node == search)
				return true;

			var left = Traverse(node.left, search, list);
			if (left) return true;

			var right = Traverse(node.right, search, list);
			if (right) return true;

			list.RemoveAt(list.Count - 1);

			return false;
		}
	}
}
