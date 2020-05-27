using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/next-greater-element-i/
	///		Submission: https://leetcode.com/submissions/detail/229329533/
	/// </summary>
	internal class P0496
	{
		public int[] NextGreaterElement(int[] nums1, int[] nums2)
		{
			var hs = new Dictionary<int, int>();
			for (var i = 0; i < nums2.Length; i++)
				hs[nums2[i]] = i;

			var res = new int[nums1.Length];

			for (var i = 0; i < nums1.Length; i++)
			{
				var j = hs[nums1[i]] + 1;

				var found = false;

				while (j < nums2.Length)
				{
					if (nums2[j] > nums1[i])
					{
						res[i] = nums2[j];
						found = true;
						break;
					}

					j++;
				}

				if (!found)
					res[i] = -1;
			}

			return res;
		}
	}
}
