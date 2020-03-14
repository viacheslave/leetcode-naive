using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/bag-of-tokens/
	///		Submission: https://leetcode.com/submissions/detail/244174982/
	/// </summary>
	internal class P0948
	{
		public int BagOfTokensScore(int[] tokens, int P)
		{
			if (tokens.Length == 0)
				return 0;

			Array.Sort(tokens);

			if (P < tokens[0])
				return 0;

			var left = 0;
			var right = tokens.Length - 1;
			var points = 0;
			var maxPoints = int.MinValue;

			while (left <= right)
			{
				while (left <= right && P >= tokens[left])
				{
					P -= tokens[left];

					left++;
					points++;

					maxPoints = Math.Max(maxPoints, points);
				}

				while (left <= right && P < tokens[left])
				{
					P += tokens[right];

					right--;
					points--;
				}
			}

			return maxPoints;
		}
	}
}
