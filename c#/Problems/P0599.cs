using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-index-sum-of-two-lists/
	///		Submission: https://leetcode.com/submissions/detail/229143961/
	/// </summary>
	internal class P0599
	{
		public string[] FindRestaurant(string[] list1, string[] list2)
		{
			var hs = new Dictionary<string, int>();
			var ms = new Dictionary<string, int>();
			var min = list1.Length + list2.Length;

			for (var i = 0; i < list1.Length; i++)
				hs.Add(list1[i], i);

			for (var i = 0; i < list2.Length; i++)
			{
				if (hs.ContainsKey(list2[i]))
				{
					ms[list2[i]] = hs[list2[i]] + i;

					if (min > ms[list2[i]])
						min = ms[list2[i]];
				}
				else
				{
					hs.Add(list2[i], i);
				}
			}


			var keys = new List<string>();
			foreach (var kvp in ms)
			{
				if (kvp.Value == min)
					keys.Add(kvp.Key);
			}

			return keys.ToArray();
		}
	}
}
