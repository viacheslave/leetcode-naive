using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/add-one-row-to-tree/
	///		Submission: https://leetcode.com/submissions/detail/239121949/
	/// </summary>
	internal class P0623
	{
		public TreeNode AddOneRow(TreeNode root, int v, int d)
		{
			if (root == null)
				return null;

			if (d == 1)
			{
				var n = new TreeNode(v);
				n.left = root;
				return n;
			}

			Traverse(root, v, d, 1);
			return root;
		}

		private void Traverse(TreeNode node, int v, int d, int depth)
		{
			if (node == null)
				return;

			if (depth == d - 1)
			{
				var n = new TreeNode(v);
				n.left = node.left;
				node.left = n;

				n = new TreeNode(v);
				n.right = node.right;
				node.right = n;

				return;
			}

			Traverse(node.left, v, d, depth + 1);
			Traverse(node.right, v, d, depth + 1);
		}
	}
}
