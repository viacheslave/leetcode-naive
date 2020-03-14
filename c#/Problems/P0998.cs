using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-binary-tree-ii/
	///		Submission: https://leetcode.com/submissions/detail/243491628/
	/// </summary>
	internal class P0998
	{
		public TreeNode InsertIntoMaxTree(TreeNode root, int val)
		{
			if (root == null) return null;

			if (val > root.val)
			{
				var newRoot = new TreeNode(val);
				newRoot.left = root;
				return newRoot;
			}

			var under = root;
			TreeNode prev = null;

			while (under != null && val < under.val)
			{
				prev = under;
				under = under.right;
			}

			var newNode = new TreeNode(val);
			newNode.left = prev.right;
			prev.right = newNode;

			return root;
		}
	}
}
