using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/intersection-of-two-arrays-ii/
	///		Submission: https://leetcode.com/submissions/detail/229750278/
	/// </summary>
	internal class P0350
	{
		public int[] Intersect(int[] nums1, int[] nums2)
		{
			var a1 = new Dictionary<int, int>();

			foreach (var a in nums1)
			{
				if (!a1.ContainsKey(a))
					a1[a] = 0;

				a1[a]++;
			}

			var res = new List<int>();
			foreach (var a in nums2)
			{
				if (a1.ContainsKey(a))
				{
					res.Add(a);
					a1[a]--;

					if (a1[a] == 0)
						a1.Remove(a);
				}
			}

			return res.ToArray();
		}
	}
}
