using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/leaf-similar-trees/
	///		Submission: https://leetcode.com/submissions/detail/234786105/
	/// </summary>
	internal class P0872
	{
		public bool LeafSimilar(TreeNode root1, TreeNode root2)
		{
			var seq1 = new List<int>();
			var seq2 = new List<int>();

			Traverse(root1, seq1);
			Traverse(root2, seq2);

			if (seq1.Count != seq2.Count)
				return false;

			for (var i = 0; i < seq1.Count; i++)
				if (seq1[i] != seq2[i])
					return false;

			return true;
		}

		void Traverse(TreeNode node, List<int> seq)
		{
			if (node == null)
				return;

			if (node.left == null && node.right == null)
				seq.Add(node.val);

			Traverse(node.left, seq);
			Traverse(node.right, seq);
		}
	}
}
