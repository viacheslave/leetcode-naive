using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/invert-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/232044898/
	/// </summary>
	internal class P0226
	{
		public TreeNode InvertTree(TreeNode root)
		{
			if (root == null)
				return root;

			Invert(root);
			return root;
		}

		public void Invert(TreeNode node)
		{
			if (node == null)
				return;

			var tmp = node.left;
			node.left = node.right;
			node.right = tmp;

			Invert(node.left);
			Invert(node.right);
		}
	}
}
