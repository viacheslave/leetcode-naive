using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/kth-largest-element-in-a-stream/
	///		Submission: https://leetcode.com/submissions/detail/229967675/
	/// </summary>
	internal class P0703
	{
		public class KthLargest
		{

			List<int> maxArray = new List<int>();
			int _k;

			public KthLargest(int k, int[] nums)
			{
				_k = k;

				for (var i = 0; i < nums.Length; i++)
				{
					maxArray.Add(nums[i]);

					Shift(maxArray);
				}
			}

			public int Add(int val)
			{
				maxArray.Add(val);

				Shift(maxArray);

				return GetKthMax(maxArray, _k);
			}

			private void Shift(List<int> arr)
			{
				if (arr.Count == 1)
					return;

				int index = arr.Count - 1;
				while (index > 0)
				{
					if (arr[index] > arr[index - 1])
					{
						var tmp = arr[index];
						arr[index] = arr[index - 1];
						arr[index - 1] = tmp;

						index--;
						continue;
					}
					break;
				}
			}

			private int GetKthMax(List<int> arr, int k)
			{
				return arr[_k - 1];
			}
		}
	}
}
