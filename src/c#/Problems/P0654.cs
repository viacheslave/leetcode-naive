using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/238863663/
	/// </summary>
	internal class P0654
	{
		public TreeNode ConstructMaximumBinaryTree(int[] nums)
		{
			var rootVal = nums.Max();
			var root = new TreeNode(rootVal);

			Build(nums.ToList(), root, 0, nums.Length - 1);

			return root;
		}

		private void Build(List<int> nums, TreeNode parent, int i, int j)
		{
			if (i == j)
				return;

			var parentIndex = nums.IndexOf(parent.val);

			List<int> leftSlice = nums.GetRange(i, parentIndex - i);
			List<int> rightSlice = nums.GetRange(parentIndex + 1, j - parentIndex);

			if (leftSlice.Count > 0)
			{
				parent.left = new TreeNode(leftSlice.Max());
				Build(nums, parent.left, i, parentIndex - 1);
			}

			if (rightSlice.Count > 0)
			{
				parent.right = new TreeNode(rightSlice.Max());
				Build(nums, parent.right, parentIndex + 1, j);
			}
		}
	}
}
