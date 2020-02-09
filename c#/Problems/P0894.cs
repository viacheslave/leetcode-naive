using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/all-possible-full-binary-trees/
	///		Submission: https://leetcode.com/submissions/detail/243330959/
	/// </summary>
	internal class P0894
	{
		public IList<TreeNode> AllPossibleFBT(int N)
		{
			if (N % 2 == 0)
				return new List<TreeNode>();

			return Build(N);
		}

		private List<TreeNode> Build(int N)
		{
			if (N == 1)
				return new List<TreeNode> { new TreeNode(0) };

			if (N == 3)
				return new List<TreeNode> { new TreeNode(0) { left = new TreeNode(0), right = new TreeNode(0) } };

			var sum = N - 1;
			var result = new List<TreeNode>();

			for (int i = 1; i < sum; i += 2)
			{
				var n1 = i;
				var n2 = sum - i;

				var leftNodes = Build(n1);
				var rightNodes = Build(n2);

				foreach (var left in leftNodes)
				{
					foreach (var right in rightNodes)
					{
						result.Add(new TreeNode(0) { left = left, right = right });
					}
				}
			}

			return result;
		}
	}
}
