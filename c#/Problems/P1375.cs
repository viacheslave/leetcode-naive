using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/bulb-switcher-iii/
	///		Submission: https://leetcode.com/submissions/detail/310649291/
	/// </summary>
	internal class P1375
	{
		public int NumTimesAllBlue(int[] light)
		{
			var set = new SortedSet<int>();
			var ans = 0;

			for (int i = 0; i < light.Length; i++)
			{
				set.Add(light[i]);
				if (set.Min == 1 && set.Max == i + 1)
					ans++;
			}

			return ans;
		}
	}
}
