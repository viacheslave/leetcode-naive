using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sliding-window-maximum/
	///		Submission: https://leetcode.com/submissions/detail/282049794/
	/// </summary>
	internal class P0239
	{
		public int[] MaxSlidingWindow(int[] nums, int k)
		{
			var startIndex = -1;
			var maxIndex = -1;
			var maxValue = int.MinValue;

			var ans = new List<int>();

			if (nums.Length == 0)
				return Array.Empty<int>();

			while (true)
			{
				int endIndex;

				// move right
				if (startIndex == -1)
				{
					startIndex = 0;
					endIndex = startIndex + k - 1;

					maxIndex = GetMaxIndex(nums, startIndex, endIndex);
					maxValue = nums[maxIndex];

					ans.Add(maxValue);
				}
				else
				{
					if (maxIndex == startIndex)
					{
						startIndex++;
						endIndex = startIndex + k - 1;

						if (endIndex == nums.Length)
							break;

						maxIndex = GetMaxIndex(nums, startIndex, endIndex);
						maxValue = nums[maxIndex];
					}
					else
					{
						startIndex++;
						endIndex = startIndex + k - 1;

						if (endIndex == nums.Length)
							break;

						if (nums[endIndex] >= maxValue)
						{
							maxIndex = endIndex;
							maxValue = nums[maxIndex];
						}
					}

					ans.Add(maxValue);
				}
			}

			return ans.ToArray();
		}

		private int GetMaxIndex(int[] nums, int startIndex, int endIndex)
		{
			var maxIndex = startIndex;
			var maxValue = nums[startIndex];

			for (int i = startIndex + 1; i <= endIndex; i++)
			{
				if (maxValue <= nums[i])
				{
					maxIndex = i;
					maxValue = nums[i];
				}
			}

			return maxIndex;
		}
	}
}
