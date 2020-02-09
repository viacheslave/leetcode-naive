using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/280161815/
	/// </summary>
	internal class P1261
	{
		/**
		* Definition for a binary tree node.
		* public class TreeNode {
		*     public int val;
		*     public TreeNode left;
		*     public TreeNode right;
		*     public TreeNode(int x) { val = x; }
		* }
		*/
		public class FindElements
		{
			private readonly HashSet<int> _values = new HashSet<int>();

			public FindElements(TreeNode root)
			{
				root.val = 0;
				Build(root);
			}

			private void Build(TreeNode node)
			{
				if (node == null)
					return;

				_values.Add(node.val);

				if (node.left != null)
				{
					node.left.val = node.val * 2 + 1;
					Build(node.left);
				}

				if (node.right != null)
				{
					node.right.val = node.val * 2 + 2;
					Build(node.right);
				}
			}

			public bool Find(int target)
			{
				return _values.Contains(target);
			}
		}

		/**
		 * Your FindElements object will be instantiated and called as such:
		 * FindElements obj = new FindElements(root);
		 * bool param_1 = obj.Find(target);
		 */
	}
}
