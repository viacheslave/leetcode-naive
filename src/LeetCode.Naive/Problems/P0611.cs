using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/valid-triangle-number/
	///		Submission: https://leetcode.com/submissions/detail/234939922/
	/// </summary>
	internal class P0611
	{
		public int TriangleNumber(int[] nums)
		{
			if (nums.Length < 3)
				return 0;

			Array.Sort(nums);

			var count = 0;

			for (var i = 0; i < nums.Length - 2; i++)
			{
				for (var j = i + 1; j < nums.Length - 1; j++)
				{
					for (var k = j + 1; k < nums.Length; k++)
					{
						if (nums[k] >= nums[i] + nums[j])
							break;

						count++;
					}
				}
			}

			return count;
		}
	}
}
