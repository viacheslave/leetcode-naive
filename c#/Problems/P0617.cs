using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/merge-two-binary-trees/
	///		Submission: https://leetcode.com/submissions/detail/234894601/
	/// </summary>
	internal class P0617
	{
		public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
		{
			if (t1 == null && t2 == null)
				return null;

			return Merge(t1, t2);
		}

		private TreeNode Merge(TreeNode node1, TreeNode node2)
		{
			TreeNode newNode = null;

			if (node1 != null && node2 != null)
			{
				newNode = new TreeNode(node1.val + node2.val);
			}
			else
			{
				var nonNull = node1 ?? node2;
				newNode = new TreeNode(nonNull.val);
			}

			if (node1?.left != null || node2?.left != null)
			{
				newNode.left = Merge(node1?.left, node2?.left);
			}

			if (node1?.right != null || node2?.right != null)
			{
				newNode.right = Merge(node1?.right, node2?.right);
			}

			return newNode;
		}
	}
}
