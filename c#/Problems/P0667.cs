using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/beautiful-arrangement-ii/
	///		Submission: https://leetcode.com/submissions/detail/394255241/
	/// </summary>
	internal class P0667
	{
		public int[] ConstructArray(int n, int k)
		{
			var ans = new List<int>();

			for (var i = 1; i <= n - k; i++)
				ans.Add(i);

			if (ans.Count == n)
				return ans.ToArray();

			ans.Add(n);

			var left = n - k;
			var right = n;
			var dir = -1;

			while (ans.Count != n)
			{
				if (dir < 0)
				{
					ans.Add(left + 1);
					left++;
				}
				else
				{
					ans.Add(right - 1);
					right--;
				}

				dir = -dir;
			}

			return ans.ToArray();
		}
	}
}
