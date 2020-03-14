using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/3sum-closest/
	///		Submission: https://leetcode.com/submissions/detail/237810432/
	/// </summary>
	internal class P0016
	{
		public int ThreeSumClosest(int[] nums, int target)
		{
			var interval = int.MaxValue;
			var sum = int.MinValue;

			Array.Sort(nums);

			for (var i = 0; i < nums.Length - 2; i++)
			{
				var j = i + 1;
				var k = nums.Length - 1;

				while (j < k)
				{
					if (nums[i] + nums[j] + nums[k] == target)
						return nums[i] + nums[j] + nums[k];

					if (nums[i] + nums[j] + nums[k] < target)
					{
						if (Math.Abs(target - (nums[i] + nums[j] + nums[k])) < interval)
						{
							interval = Math.Abs(target - (nums[i] + nums[j] + nums[k]));
							sum = nums[i] + nums[j] + nums[k];
						}

						j++; continue;
					}

					if (nums[i] + nums[j] + nums[k] > target)
					{
						if (Math.Abs(target - (nums[i] + nums[j] + nums[k])) < interval)
						{
							interval = Math.Abs(target - (nums[i] + nums[j] + nums[k]));
							sum = nums[i] + nums[j] + nums[k];
						}

						k--; continue;
					}

					while (k - 1 >= 0 && nums[k - 1] == nums[k])
						k--;

					while (j + 1 < nums.Length && nums[j + 1] == nums[j])
						j++;

					k--; j++;
				}

				while (i + 1 < nums.Length && nums[i + 1] == nums[i])
					i++;
			}

			return sum;
		}
	}
}
