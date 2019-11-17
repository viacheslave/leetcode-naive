using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/flip-equivalent-binary-trees/
	///		Submission: https://leetcode.com/submissions/detail/243299710/
	/// </summary>
	internal class P0951
	{
		public bool FlipEquiv(TreeNode root1, TreeNode root2)
		{
			return AreEqual(root1, root2);
		}

		private bool AreEqual(TreeNode node1, TreeNode node2)
		{
			if (node1 == null && node2 == null)
				return true;

			if (node1 == null && node2 != null) return false;
			if (node1 != null && node2 == null) return false;

			return (node1.val == node2.val &&
					(
							(AreEqual(node1.left, node2.left) && AreEqual(node1.right, node2.right)) ||
							(AreEqual(node1.left, node2.right) && AreEqual(node1.right, node2.left))
					));
		}
	}
}
