using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/n-ary-tree-postorder-traversal/
	///		Submission: https://leetcode.com/submissions/detail/228187902/
	/// </summary>
	internal class P0590
	{
		public IList<int> Postorder(NodeChildren root)
		{
			var res = new List<int>();

			CheckNode(res, root);

			return res;
		}

		private void CheckNode(List<int> res, NodeChildren node)
		{
			if (node == null)
				return;

			if (node.children != null)
				foreach (var n in node.children)
					CheckNode(res, n);

			res.Add(node.val);
		}
	}
}
