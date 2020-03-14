using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/unique-binary-search-trees/
	///		Submission: https://leetcode.com/submissions/detail/230909436/
	/// </summary>
	internal class P0096
	{
		public int NumTrees(int n)
		{
			var hs = new Dictionary<int, int>()
			{
				[0] = 1,
				[1] = 1,
				[2] = 2,
				[3] = 5,
				[4] = 14,
				[5] = 42
			};

			if (n < 6)
				return hs[n];

			var index = 6;
			while (index <= n)
			{
				var val = 0;
				for (var i = 0; i < index / 2; i++)
				{
					val += 2 * (hs[index - 1 - i] * hs[i]);
				}

				if (index % 2 == 1)
					val += hs[index / 2] * hs[index / 2];

				hs[index] = val;

				index++;
			}

			return hs[index - 1];
		}
	}
}
