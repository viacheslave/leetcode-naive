using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/282928648/
	/// </summary>
	internal class P0331
	{
		public bool IsValidSerialization(string preorder)
		{
			var values = preorder.Split(',').ToList();

			if (values.Count == 0)
				return true;

			var nodeIndexes = new List<int>();
			for (int i = 0; i < values.Count; i++)
			{
				if (values[i] != "#")
					nodeIndexes.Add(i);
			}

			while (values.Count > 0)
			{
				if (nodeIndexes.Count == 0)
					break;

				var lastNodeIndex = nodeIndexes[nodeIndexes.Count - 1];

				var leftIndex = lastNodeIndex + 1;
				var rightIndex = lastNodeIndex + 2;

				if (leftIndex >= values.Count || rightIndex >= values.Count)
					return false;

				var left = values[leftIndex];
				var right = values[rightIndex];

				if (left != "#" || right != "#")
					return false;

				// remove
				values.RemoveRange(lastNodeIndex, 2);
				nodeIndexes.RemoveAt(nodeIndexes.Count - 1);
			}

			return values.Count == 1 && values[0] == "#";
		}
	}
}
