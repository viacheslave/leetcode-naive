﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/same-tree/
	///		Submission: https://leetcode.com/submissions/detail/228679084/
	/// </summary>
	internal class P0100
	{
		public bool IsSameTree(TreeNode p, TreeNode q)
		{
			return CheckNode(p, q);


		}

		private bool CheckNode(TreeNode p, TreeNode q)
		{
			if (p == null && q == null)
				return true;

			if (p != null && q != null)
			{
				var nodesEqual = p.val == q.val;

				return nodesEqual &&
						CheckNode(p.left, q.left) &&
						CheckNode(p.right, q.right);
			}

			return false;
		}
	}
}