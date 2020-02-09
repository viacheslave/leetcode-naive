using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
	///		Submission: https://leetcode.com/submissions/detail/237983418/
	/// </summary>
	internal class P0235
	{
		private bool _found = false;

		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{
			var listP = new List<TreeNode>();
			var listQ = new List<TreeNode>();

			_found = false;
			Traverse(root, p, listP);

			_found = false;
			Traverse(root, q, listQ);

			var elCommon = root;

			while (listP.Count > 0 && listQ.Count > 0)
			{
				var elP = listP[0];
				var elQ = listQ[0];

				listP.RemoveAt(0);
				listQ.RemoveAt(0);

				if (elP != elQ)
					return elCommon;

				elCommon = elP;
			}

			return elCommon;
		}

		private void Traverse(TreeNode node, TreeNode target, List<TreeNode> list)
		{
			if (node == null)
				return;

			if (node == target)
			{
				list.Add(node);
				_found = true;
			}

			if (_found)
				return;

			list.Add(node);

			Traverse(node.left, target, list);
			if (_found) return;

			Traverse(node.right, target, list);
			if (_found) return;

			list.RemoveAt(list.Count - 1);
		}
	}
}
