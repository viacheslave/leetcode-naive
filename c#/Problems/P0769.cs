using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/max-chunks-to-make-sorted/
	///		Submission: https://leetcode.com/submissions/detail/240275285/
	/// </summary>
	internal class P0769
	{
		public int MaxChunksToSorted(int[] arr)
		{
			var set = new SortedSet<int>();
			var processed = 0;
			var chunks = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				set.Add(arr[i]);
				if (set.Count - 1 == set.Max - processed)
				{
					chunks++;
					processed += set.Count;
					set = new SortedSet<int>();
				}
			}

			return chunks;
		}
	}
}
