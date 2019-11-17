using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/3sum/
	///		Submission: https://leetcode.com/submissions/detail/237807992/
	/// </summary>
	internal class P0015
	{
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			var res = new List<IList<int>>();

			Array.Sort(nums);

			for (var i = 0; i < nums.Length - 2; i++)
			{
				var j = i + 1;
				var k = nums.Length - 1;

				while (j < k)
				{
					if (nums[i] + nums[j] + nums[k] < 0)
					{
						j++; continue;
					}

					if (nums[i] + nums[j] + nums[k] > 0)
					{
						k--; continue;
					}

					res.Add(new List<int>() { nums[i], nums[j], nums[k] });

					while (k - 1 >= 0 && nums[k - 1] == nums[k])
						k--;

					while (j + 1 < nums.Length && nums[j + 1] == nums[j])
						j++;


					k--; j++;
				}

				while (i + 1 < nums.Length && nums[i + 1] == nums[i])
					i++;
			}

			return res;
		}
	}
}
