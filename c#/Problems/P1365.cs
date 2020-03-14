using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/submissions/
	///		Submission: https://leetcode.com/submissions/detail/308303896/
	/// </summary>
	internal class P1365
	{
		public int[] SmallerNumbersThanCurrent(int[] nums)
		{
			var list = nums.ToList();
			list.Sort();

			var map = new Dictionary<int, int>();
			var last = -1;

			for (int i = 0; i < list.Count; i++)
			{
				if (i == 0)
				{
					map[list[i]] = 0;
					last = 0;
					continue;
				}

				if (list[i] != list[i - 1])
				{
					map[list[i]] = i;
					last++;
				}
			}

			return nums.Select(n => map[n]).ToArray();
		}
	}
}
