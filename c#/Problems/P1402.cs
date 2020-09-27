using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reducing-dishes/
	///		Submission: https://leetcode.com/submissions/detail/401378313/
	/// </summary>
	internal class P1402
	{
		public int MaxSatisfaction(int[] satisfaction)
		{
			Array.Sort(satisfaction);

			var total = 0;
			var current = 0;

			for (int i = satisfaction.Length - 1; i >= 0; i--)
			{
				var taken = -1;

				for (int point = i; point >= 0; point--)
				{
					if (total + current + satisfaction[point] > total)
					{
						total = total + current + satisfaction[point];
						current = current + satisfaction[point];

						taken = point;
					}
				}

				if (taken != -1)
					i = taken;
			}

			return total;
		}
	}
}
