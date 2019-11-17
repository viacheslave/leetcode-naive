using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reconstruct-a-2-row-binary-matrix/
	///		Submission: https://leetcode.com/submissions/detail/278498730/
	/// </summary>
	internal class P1253
	{
		public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
		{
			var cols = new Tuple<int, int>[colsum.Length];

			var upperLeft = upper;
			var lowerLeft = lower;

			for (var index = 0; index < colsum.Length; index++)
			{
				if (colsum[index] == 2)
				{
					cols[index] = new Tuple<int, int>(1, 1);
					upperLeft--;
					lowerLeft--;
					continue;
				}

				if (colsum[index] == 0)
				{
					cols[index] = new Tuple<int, int>(0, 0);
					continue;
				}
			}

			var ones = colsum.Where(c => c == 1).Sum();

			if (upperLeft + lowerLeft != ones)
				return new List<IList<int>>();

			for (var i = 0; i < cols.Length; i++)
			{
				if (cols[i] != null)
					continue;

				if (upperLeft > 0)
				{
					cols[i] = new Tuple<int, int>(1, 0);
					upperLeft--;
					continue;
				}

				cols[i] = new Tuple<int, int>(0, 1);
				lowerLeft--;
			}

			if (upperLeft != 0 || lowerLeft != 0)
				return new List<IList<int>>();

			return new List<IList<int>>() { cols.Select(x => x.Item1).ToList(), cols.Select(x => x.Item2).ToList() };
		}
	}
}
