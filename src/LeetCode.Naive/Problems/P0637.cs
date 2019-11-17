using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/average-of-levels-in-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/228185597/
	/// </summary>
	internal class P0637
	{
		public IList<double> AverageOfLevels(TreeNode root)
		{
			var res = new List<IList<int>>();

			CheckNode(res, root, 0);

			var av = new List<double>();

			foreach (var r in res)
			{
				long sum = 0;
				foreach (var el in r)
					sum += el;

				av.Add(1.0 * sum / r.Count);
			}

			return av;
		}

		private void CheckNode(List<IList<int>> res, TreeNode node, int depth)
		{
			if (node == null)
				return;

			if (res.Count == depth)
				res.Add(new List<int>());

			res[depth].Add(node.val);

			depth++;

			if (node.left != null)
				CheckNode(res, node.left, depth);

			if (node.right != null)
				CheckNode(res, node.right, depth);
		}
	}
}
