using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/next-permutation/
	///		Submission: https://leetcode.com/submissions/detail/229575125/
	/// </summary>
	internal class P0031
	{
		public void NextPermutation(int[] nums)
		{
			if (nums.Length < 2)
				return;

			var baseIndex = nums.Length - 2;

			while (baseIndex >= 0)
			{
				for (var i = nums.Length - 1; i > baseIndex; i--)
				{
					if (nums[baseIndex] < nums[i])
					{
						var tmp = nums[baseIndex];
						nums[baseIndex] = nums[i];
						nums[i] = tmp;

						if (baseIndex + 1 < nums.Length - 1)
						{
							Sort(nums, baseIndex + 1);
						}

						return;
					}
				}

				baseIndex--;
			}

			Array.Reverse(nums);
		}

		private void Swap(int[] nums, int left, int right)
		{
			var tmp = nums[left];
			nums[left] = nums[right];
			nums[right] = tmp;
		}

		private void Sort(int[] nums, int start)
		{
			var b = start + 1;

			while (b < nums.Length)
			{
				var current = b;
				while (current > start)
				{
					if (nums[current] < nums[current - 1])
					{
						Swap(nums, current, current - 1);
						current--;
						continue;
					}
					break;
				}

				b++;
			}
		}
	}
}
