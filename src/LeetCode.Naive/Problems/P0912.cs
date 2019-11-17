using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sort-an-array/
	///		Submission: https://leetcode.com/submissions/detail/239301310/
	/// </summary>
	internal class P0912
	{
		public int[] SortArray(int[] nums)
		{
			return GetSorted(nums, 0, nums.Length - 1);
		}

		private int[] GetSorted(int[] nums, int v1, int v2)
		{
			if (v2 == v1)
				return new int[] { nums[v1] };

			if (v2 - v1 == 1)
			{
				if (nums[v1] < nums[v2])
					return new int[] { nums[v1], nums[v2] };
				else
					return new int[] { nums[v2], nums[v1] };
			}

			var mid = (v1 + v2) / 2;

			return Merge(GetSorted(nums, v1, mid), GetSorted(nums, mid + 1, v2));
		}

		private int[] Merge(int[] arr1, int[] arr2)
		{
			var i1 = 0;
			var i2 = 0;

			var res = new List<int>(arr1.Length + arr2.Length);

			while (i1 < arr1.Length || i2 < arr2.Length)
			{
				if (i1 >= arr1.Length)
				{
					res.Add(arr2[i2]);
					i2++;
					continue;
				}

				if (i2 >= arr2.Length)
				{
					res.Add(arr1[i1]);
					i1++;
					continue;
				}

				if (arr1[i1] < arr2[i2])
				{
					res.Add(arr1[i1]);
					i1++;
					continue;
				}
				else
				{
					res.Add(arr2[i2]);
					i2++;
					continue;
				}
			}

			return res.ToArray();
		}
	}
}
